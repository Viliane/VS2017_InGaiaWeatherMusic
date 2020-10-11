# InGaiaWeatherMusic

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

Esta WebAPI disponibiliza uma Playlist de músicas a partir da temperatura informada de uma cidade no Brasil. Categoria de músicas disponibilizadas no momento são Pop, Rock e Focus. 

# Descrição do Projeto

  Para a criação do projeto utilizei o Visual Studio 2017, AspNetCore, C#, Injeção de dependência, Swagger. A arquitetura utilizada foi MVC por entender que o projeto não tem um nível de complexidade alta e atender ao requisito exigidos.
  Para um bom entendimento divide o projeto em 3: 
    - InGaiaWeatherMusic.API
    - InGaiaWeatherMusic.Business
    - InGaiaWeatherMusic.Data

### Configurações Necessárias

Existe uma configuração de segurança para acessar os métodos da API(necessário Token para autorização), com isto foi criada uma Secret.json que não é disponiblizada no Git. Para realizar a configuração de chave é necessário realizar os seguintes passos:
- Após baixar o projeto;
- Abrir o Visual Studio 2017;
- Clicar com botão direto em InGaiaWeatherMusic.API;
- Clicar em Manage User Secret; 
- Incluir no arquivo o seguint exemplo: "Secret": "gdtfdjksjdksjb557sd578ds7d4s87d7d492b708e"

A API faz acessos a API do Spotify, deste modo é necessário seu cadastro no Spotify Developer para  obter um clientId e SecretID. Do mesmo modo estas duas chaves dever ser adicionadas no arquivo Secret.json. Exemplo:
- "ClienId": "e245d4s5787df87f87df8787d8f78dsd",
- "SecretId": "32as5d4sa8d7sd87as8d78sa7da8s7d"

Para realizar login no API use o seguinte usuario:
-Nome: teste
-Senha: teste