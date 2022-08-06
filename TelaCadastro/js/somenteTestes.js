
fetch('https://viacep.com.br/ws/00010000/json/') // recebe a url onde vai ser feita a requisição
.then(response => response.json()) // pega o objeto de retorno e transforma em Json
.then(objeto => {
    if(objeto.erro){
        throw Error('Esse cep não foi encontrado na base de dados')
    }
    else{
        console.log(objeto)
    }  
}) // pega o o bjeto de retorno e mostra na tela.
.catch(erro => console.log(erro))
.finally(() => console.log('processamento finalizado!!'))
 



async function buscaEnderenco() {

    try {
        var consultaCep = await fetch('https://viacep.com.br/ws/01000000/json/');
        console.log("fetch => ", consultaCep);

        var objetoJson = await consultaCep.json();
        console.log("Objeto Json => ", objetoJson);

        if(objetoJson.erro){
            throw Error('Esse cep não foi encontrado na base de dados')
        }

    } catch (erro) {
        console.log(erro)
    }
}


buscaEnderenco();


const MontaDadosCadastro = () => {
    


}


/* executando varias Requicições */

async function buscaEnderenco(cep) {

    try {
        var consultaCep = await fetch(`https://viacep.com.br/ws/${cep}/json/`);
        var objetoJson = await consultaCep.json(); 

        if(objetoJson.erro){
            throw Error('Esse cep não foi encontrado na base de dados')
        }
        return objetoJson;
    } catch (erro) {
        console.log(erro)
    }
}

let ceps = ['01001000', '74936580']

let cepsPromise = ceps.map(cep => buscaEnderenco(cep))
Promise.all(cepsPromise).then(respostas => console.log("Retorno da promise", respostas))

    
let cep = document.getElementById('cep');

cep.addEventListener('input', (e) =>{

    console.log(e)

    if(cep.value.length >= 8){
        BuscaCep(cep.value)
    }
})
