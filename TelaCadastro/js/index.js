/* fazendo a busca do cep na api via Cep e colocando nos campos do formulario com Fetch de maneira assincrona.*/

const CEP = {
    Estado: 'estado',
    Endereco: 'endereco',
    Bairro: 'bairro',
    Cidade: 'cidade'
}

const Usuario = {
    Nome: 'nome',
    DataNascimento: 'nascimento',
    Telefone: 'telefone',
    CPF: 'CPF',
    Email:'email'
}


const campoCep = document.getElementById('cep');

campoCep.addEventListener('input', () =>{
    if(campoCep.value.length >= 8){
        BuscaCep(campoCep.value)
    }
    if(campoCep.value.length == 0){
        HabilitaCamposCep()
    }
})

async function BuscaCep(cep){
    
    let consultarCep = await fetch(`https://viacep.com.br/ws/${cep}/json/`);
    let CepJson = await consultarCep.json(); 

    let mensagemErro = document.querySelector("#menssagemErro").children[0]

    if(CepJson.erro){
      mensagemErro.textContent = 'Cep não Valido'
    }
    else{
        mensagemErro.textContent = ''
        preencheCamposCep(CepJson)
    }
}


function preencheCamposCep(cep){
    InsereValor(CEP.Estado, cep.uf)
    DesabilitaCampo(CEP.Estado)

    InsereValor(CEP.Endereco, cep.logradouro)
    DesabilitaCampo(CEP.Endereco)

    InsereValor(CEP.Bairro, cep.bairro)
    DesabilitaCampo(CEP.Bairro)

    InsereValor(CEP.Cidade, cep.localidade)
    DesabilitaCampo(CEP.Cidade)
}

function InsereValor(tag, valor){
    const input = document.getElementById(tag)
    input.value = valor;
}

function retornaValorID(tag){
    return document.getElementById(tag).value
}

function DesabilitaCampo(tag){
    document.getElementById(tag).disabled = true
}

function AtivaCampo(tag){
    document.getElementById(tag).disabled = false
}

const HabilitaCamposCep = () => {
    document.getElementById('#estado').disabled = false
    document.getElementById('#endereco').disabled = false
    document.getElementById('#bairro').disabled = false
    document.getElementById('#cidade').disabled = false
}


document.querySelector('#enviar').addEventListener('click', (e) => {
    e.preventDefault()
    enviaRequisicaoCadastro()
})

const urlApiCadastro = 'http://localhost:7162/CadastroUsuario'


async function enviaRequisicaoGet(){

    var chamada = await fetch(urlApiCadastro)

    console.log(await chamada.json())
}

async function enviaRequisicaoCadastro(){
 
    let data = MontaDadosCadastro();

    const options = {
        method: 'POST',
        body: JSON.stringify(data),
        headers: {
        'Content-Type': 'application/json',
        }
    }

    let consulta = await fetch(urlApiCadastro, options)

    console.log(consulta)

    let retorno = await consulta.json();

    console.log(retorno)
}


const MontaDadosCadastro = () => {
    return {
        Nome: retornaValorID(Usuario.Nome),
        CPF: retornaValorID(Usuario.CPF),
        Email: retornaValorID(Usuario.Email),
        DataNascimento: retornaValorID(Usuario.DataNascimento),
        NumeroContado: retornaValorID(Usuario.Telefone),
        Endereco: {
            Endereco: retornaValorID(CEP.Endereco),
            Cep: retornaValorID('cep'),
            Numero: retornaValorID('numero'),
            Complemento: retornaValorID('complemento'),
            Bairro: retornaValorID(CEP.Bairro),
            Cidade: retornaValorID(CEP.Cidade),
            SiglaEstado: retornaValorID(CEP.Estado)
        }
    }
}
