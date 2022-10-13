using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIFibra.Data;
using APIFibra.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIFibra.Controllers
{

    [Authorize]
    public class ImportaController : BaseApiController
    {
        private readonly CotaRepository _cota;
        private RecadastroRepository _recadastroRepository;

        public ImportaController(CotaRepository cotaRepository, RecadastroRepository recadastroRepository)
        {
            _recadastroRepository = recadastroRepository;
            _cota = cotaRepository;
        }

        [HttpPost("cotas")]
        public async Task<ActionResult> addCotas(IFormFile file)
        {
            Cota cota;
            Cota cotaDB;
            var linha = "";
            
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                var count = 0;
                var numero = false;
                
                while (reader.Peek() >= 0)
                {
                    linha = await reader.ReadLineAsync();

                    if (numero = int.TryParse(linha.Substring(0, 6), out int numCotista) == false)
                    {
                        await _cota.SaveAllAsync();
                        return StatusCode(500, $"Erro no Cotista: {linha.Substring(0, 6)}, ao tentar converter o número de cotista.");
                    }
                    
                    if (numero = double.TryParse((linha.Substring(57, 18))
                            .Replace(".", ","), out double NumeroCotas) == false)
                    {
                        await _cota.SaveAllAsync();
                        return StatusCode(500, $"Erro no Cotista: {linha.Substring(0, 6)}, ao tentar converter a quantidade de cotas.");
                    }

                    cota = new Cota()
                    {
                        Numcotista = int.Parse(linha.Substring(0, 6)),
                        Nome = linha.Substring(6, 40).Trim(),
                        CPF = linha.Substring(46, 11).Trim(),
                        NumeroCotas = Math.Round(float.Parse((linha.Substring(57, 18))
                            .Replace(".",",")),6)
                    };

                    cotaDB = await _cota.GetCotaByIdAsync(cota.Numcotista);

                    if (cotaDB != null)
                    {
                        if (cota != cotaDB)
                        {
                            count++;
                            _cota.UpdateCota(cota);
                        }
                    }
                    else
                    {
                        count++;
                        _cota.IncluiCota(cota);
                    }
                    
                    if (count++ > 999)
                    {
                        await _cota.SaveAllAsync();
                        count = 0;
                    }

                }
            }
            
            await _cota.SaveAllAsync();
            
            return Ok("Arquivo de cotas incluído com sucesso.");
        }
        
        [HttpPost("recadastros")]
        public async Task<ActionResult> addRecadastros(IFormFile file)
        {
            Recadastro recadastro;
            Recadastro recadastroDB;
            var linha = "";
            
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                var count = 0;
                var numero = false;
                
                while (reader.Peek() >= 0)
                {
                    linha = await reader.ReadLineAsync();

                    var indexAnt = linha.IndexOf(linha, ';');
                    var numCotista = linha.Substring(0, indexAnt - 1);
                    var index = linha.IndexOf(linha, indexAnt + 1, ';');
                    var nomeCotista = linha.Substring(indexAnt + 1, index - indexAnt - 1);
                    
                    Console.WriteLine(numCotista + ' ' + nomeCotista);

                    break;
                    
                }
            }
            
         
            return Ok("Arquivo de Recadastro incluído com sucesso.");
        }
        
    }
}