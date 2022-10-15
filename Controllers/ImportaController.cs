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
using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;

namespace APIFibra.Controllers
{

    [Authorize]
    public class ImportaController : BaseApiController
    {
        private readonly CotaRepository _cota;
        private readonly RecadastroRepository _recadastro;

        public ImportaController(CotaRepository cotaRepository, RecadastroRepository recadastroRepository)
        {
            _recadastro = recadastroRepository;
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
        
        [HttpPost("recadastro")]
        public async Task<ActionResult> addRecadastro(IFormFile file)
        {
            Recadastro recadastro;
            Recadastro recadastroDB;
            var linha = "";

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                var count = 0;
                
                while (reader.Peek() >= 0)
                {
                    if (count++ == 0)
                    {
                        linha = await reader.ReadLineAsync();    
                    }
                    
                    linha = await reader.ReadLineAsync();

                    if (linha == null)
                    {
                        return StatusCode(500, "Erro ao ler arquivo texto.");
                    }
                    
                    var indexAnt = linha.IndexOf(';');
                    
                    if (int.TryParse(linha.Substring(0, indexAnt - 1), out int numCotista) == false)
                    {
                        await _recadastro.SaveAllAsync();
                        return StatusCode(500, $"Erro no Cotista: {linha.Substring(0, indexAnt - 1)}, ao tentar converter o número de cotista.");
                    }
                    
                    var index = linha.IndexOf(';', indexAnt + 1);
                    var nomeCotista = linha.Substring(indexAnt + 1, index - indexAnt - 1);
                    indexAnt = linha.IndexOf(';', index + 1);
                    var endereco = linha.Substring(index + 1, indexAnt - index - 1);
                    index = linha.IndexOf(';', indexAnt + 1);
                    var bairro = linha.Substring(indexAnt + 1, index - indexAnt - 1);
                    indexAnt = linha.IndexOf(';', index + 1);
                    var cidade = linha.Substring(index + 1, indexAnt - index - 1);
                    index = linha.IndexOf(';', indexAnt + 1);
                    var uf = linha.Substring(indexAnt + 1, index - indexAnt - 1);
                    indexAnt = linha.IndexOf(';', index + 1);
                    var cep = linha.Substring(index + 1, indexAnt - index - 1);
                    index = linha.IndexOf(';', indexAnt + 1);
                    var telefone = linha.Substring(indexAnt + 1, index - indexAnt - 1);
                    indexAnt = linha.IndexOf(';', index + 1);
                    var celular = linha.Substring(index + 1, indexAnt - index - 1);
                    index = linha.IndexOf(';', indexAnt + 1);
                    var cpf = linha.Substring(indexAnt + 1, index - indexAnt - 1);
                    indexAnt = linha.IndexOf(';', index + 1);
                    var sexo = linha.Substring(index + 1, indexAnt - index - 1);
                    index = linha.IndexOf(';', indexAnt + 1);
                    var nacionalidade = linha.Substring(indexAnt + 1, index - indexAnt - 1);
                    indexAnt = linha.IndexOf(';', index + 1);
                    var indentTipo = linha.Substring(index + 1, indexAnt - index - 1);
                    index = linha.IndexOf(';', indexAnt + 1);
                    var identNum = linha.Substring(indexAnt + 1, index - indexAnt - 1);
                    indexAnt = linha.IndexOf(';', index + 1);
                    var identOrgao = linha.Substring(index + 1, indexAnt - index - 1);
                    index = linha.IndexOf(';', indexAnt + 1);
                    
                    if (DateTime.TryParse (linha.Substring(indexAnt + 1, index - indexAnt - 1), out DateTime identEmissao) == false)
                    {
                        if (linha.Substring(indexAnt + 1, index - indexAnt - 1).Length > 0)
                        {
                            await _recadastro.SaveAllAsync();
                            return StatusCode(500, $"Erro no Cotista: {numCotista}, ao tentar converter a data de emissão da identidade.");    
                        }
                    }
                    
                    indexAnt = linha.IndexOf(';', index + 1);
                    var localNascimento = linha.Substring(index + 1, indexAnt - index - 1);
                    index = linha.IndexOf(';', indexAnt + 1);
                    
                    if (DateTime.TryParse (linha.Substring(indexAnt + 1, index - indexAnt - 1), out DateTime dataNascimento) == false)
                    {
                        if (linha.Substring(indexAnt + 1, index - indexAnt - 1).Length > 0)
                        {
                            await _recadastro.SaveAllAsync();
                            return StatusCode(500, $"Erro no Cotista: {numCotista}, ao tentar converter a data de nascimento.");    
                        }
                    }
                    
                    indexAnt = linha.IndexOf(';', index + 1);
                    var estadoCivil = linha.Substring(index + 1, indexAnt - index - 1);
                    index = linha.IndexOf(';', indexAnt + 1);
                    var regimeBens = linha.Substring(indexAnt + 1, index - indexAnt - 1);
                    indexAnt = linha.IndexOf(';', index + 1);
                    var nomeConjuge = linha.Substring(index + 1, indexAnt - index - 1);
                    index = linha.IndexOf(';', indexAnt + 1);
                    var cpfConjuge = linha.Substring(indexAnt + 1, index - indexAnt - 1);
                    indexAnt = linha.IndexOf(';', index + 1);
                    var email = linha.Substring(index + 1, indexAnt - index - 1);
                    index = linha.IndexOf(';', indexAnt + 1);
                    var ocupacaoProfissional = linha.Substring(indexAnt + 1, index - indexAnt - 1);
                    indexAnt = linha.IndexOf(';', index + 1);
                    var profissao = linha.Substring(index + 1, indexAnt - index - 1);
                    index = linha.IndexOf(';', indexAnt + 1);
                    var entidadeTrabalhoNome = linha.Substring(indexAnt + 1, index - indexAnt - 1);
                    indexAnt = linha.IndexOf(';', index + 1);
                    var entidadeTrabalhoCodigo = linha.Substring(index + 1, indexAnt - index - 1);
                    index = linha.IndexOf(';', indexAnt + 1);
                    var entidadeTrabalhoTelefone = linha.Substring(indexAnt + 1, index - indexAnt - 1);
                    indexAnt = linha.IndexOf(';', index + 1);
                    
                    if (float.TryParse (linha.Substring(index + 1, indexAnt - index - 1), out float remuneracaoMensal) == false)
                    {
                        if (linha.Substring(index + 1, indexAnt - index - 1).Length > 0)
                        {
                            await _recadastro.SaveAllAsync();
                            return StatusCode(500, $"Erro no Cotista: {numCotista}, ao tentar converter a remuneração mensal.");    
                        }
                    }
                    
                    index = linha.IndexOf(';', indexAnt + 1);

                    if (float.TryParse (linha.Substring(indexAnt + 1, index - indexAnt - 1), out float patrimonio) == false)
                    {
                        if (linha.Substring(indexAnt + 1, index - indexAnt - 1).Length > 0)
                        {
                            await _recadastro.SaveAllAsync();
                            return StatusCode(500, $"Erro no Cotista: {numCotista}, ao tentar converter patrimônio.");    
                        }
                    }
                    
                    // return Ok("legal ate aqui");
                    indexAnt = linha.IndexOf(';', index + 1);
                    var bancoNome = linha.Substring(index + 1, indexAnt - index - 1);
                    index = linha.IndexOf(';', indexAnt + 1);
                    var bancoNumero = linha.Substring(indexAnt + 1, index - indexAnt - 1);
                    indexAnt = linha.IndexOf(';', index + 1);
                    var bancoAgencia = linha.Substring(index + 1, indexAnt - index - 1);
                    index = linha.IndexOf(';', indexAnt + 1);
                    var bancoContaCorrente = linha.Substring(indexAnt + 1, index - indexAnt - 1);
                    indexAnt = linha.IndexOf(';', index + 1);
                    var dataAlteracao = linha.Substring(index + 1, indexAnt - index - 1);
                    index = linha.IndexOf(';', indexAnt + 1);
                    
                    if (DateTime.TryParse (linha.Substring(indexAnt + 1, index - indexAnt - 1), out DateTime dataRecadastramento) == false)
                    {
                        if (linha.Substring(indexAnt + 1, index - indexAnt - 1).Length > 0)
                        {
                            await _recadastro.SaveAllAsync();
                            return StatusCode(500, $"Erro no Cotista: {numCotista}, ao tentar converter a data de recadastramento.");    
                        }
                    }
                    
                    indexAnt = linha.IndexOf(';', index + 1);
                    var dataInclusao = linha.Substring(index + 1, indexAnt - index - 1);
                    index = linha.IndexOf(';', indexAnt + 1);
                    var filiacaoPai = linha.Substring(indexAnt + 1, index - indexAnt - 1);
                    indexAnt = linha.IndexOf(';', index + 1);
                    var filiacaoMae = linha.Substring(index + 1, indexAnt - index - 1);
                    index = linha.IndexOf(';', indexAnt + 1);
                    var politicamenteExposto = linha.Substring(indexAnt + 1, index - indexAnt - 1);
                    indexAnt = linha.IndexOf(';', index + 1);
                    var perfilInvestidor = linha.Substring(index + 1, indexAnt - index - 1);
                    index = linha.IndexOf(';', indexAnt + 1);
                    
                    if (DateTime.TryParse (linha.Substring(indexAnt + 1, index - indexAnt - 1), out DateTime dataPerfil) == false)
                    {
                        if (linha.Substring(indexAnt + 1, index - indexAnt - 1).Length > 0)
                        {
                            await _recadastro.SaveAllAsync();
                            return StatusCode(500, $"Erro no Cotista: {numCotista}, ao tentar converter a data de perfil.");    
                        }
                    }
                    
                    

                    recadastro = new Recadastro()
                    {
                        Numcotista = numCotista,
                        Nome = nomeCotista,
                        Endereco = endereco,
                        Bairro = bairro,
                        Cidade = cidade,
                        Uf = uf,
                        Cep = cep,
                        Telefone = telefone,
                        Celular = celular,
                        Cpf = cpf,
                        Sexo = sexo,
                        Nacionalidade = nacionalidade,
                        IdentTipo = indentTipo,
                        IdentNum = identNum,
                        IdentOrgao = identOrgao,
                        IdentEmissao = identEmissao,
                        LocalNascimento = localNascimento,
                        DataNascimento = dataNascimento,
                        EstadoCivil = estadoCivil,
                        RegimeBens = regimeBens,
                        NomeConjuge = nomeConjuge,
                        CpfConjuge = cpfConjuge,
                        Email = email,
                        OcupacaoProfissional = ocupacaoProfissional,
                        Profissao = profissao,
                        EntidadeTrabalhoNome = entidadeTrabalhoNome,
                        EntidadeTrabalhoCodigo = entidadeTrabalhoCodigo,
                        EntidadeTrabalhoTelefone = entidadeTrabalhoTelefone,
                        RemuneracaoMensal = remuneracaoMensal,
                        Patrimonio = patrimonio,
                        BancoNome = bancoNome,
                        BancoNumero = bancoNumero,
                        BancoAgencia = bancoAgencia,
                        BancoConta = bancoContaCorrente,
                        DataCadastro = dataRecadastramento,
                        FiliacaoPai = filiacaoPai,
                        FiliacaoMae = filiacaoMae,
                        PessoaPolitica = politicamenteExposto,
                        PerfilInvestidor = perfilInvestidor,
                        PerfilData = dataPerfil
                    };
                    
                    recadastroDB = await _recadastro.GetRecadastroByIdAsync(numCotista);

                    

                    if (recadastroDB != null)
                    {
                        
                        if (recadastro != recadastroDB)
                        {
                            count++;
                            _recadastro.UpdateRecadastro(recadastro);
                        }
                    }
                    else
                    {
                        count++;
                        _recadastro.IncluiRecadastro(recadastro);
                    }
                    
                    if (count++ > 999)
                    {
                        await _recadastro.SaveAllAsync();
                        count = 0;
                    }
                }
            }
            
            await _recadastro.SaveAllAsync();
            return Ok("Arquivo de recadastro incluído com sucesso.");
        }
    }
}