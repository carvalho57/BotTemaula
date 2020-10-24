# Bot Tem aula

Bot do telegram para o grupo do Tem Aula  [Link para o grupo](https://t.me/TemAula)

# O que voce precisa ter para rodar o projeto 
Instalado
* [Download Dotnet Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)
* [Ngrok](https://ngrok.com/download)

Um [Bot](https://core.telegram.org/bots#3-how-do-i-create-a-bot)  e o token de autorização, que se parece com isso *1234567:4TT8bAc8GHUspu3ERYn-KGcvsvGB9u_n4ddy*.

Tudo pronto então vamos rodar o projeto.

# Rodando o projeto
Primeiro execute o ngrok, o ngrok vai permitir que você consiga acessar sua maquina local através de um subdomain
oferecido pelo proprio ngrok
```
    ngrok http 8443
```
Com o ngrok rodando ele vai te oferecer duas url que apontam para o seu localhost
copie a que tem *https*

Segundo você tem que configurar o appsettings.json colocando o token de autorização e a url que você acabou de copiar do ngrok.

```
"BotConfiguration": {
    "BotToken": "SEU TOKEN AQUI",
    "UrlWebHook": "URL OFERECIDA PELO NGROK, ESCOLHA HTTPS"
  }
```

Com tudo configurado e hora de rodar:

Na raiz do projeto execute esses comandos

```
    dotnet restore
    dotnet run
```
Tudo pronto agora acesse seu bot e teste os comandos