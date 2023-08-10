# API-DestinosDeViagens
API Rest em C# com integração do ChatGPT

<br><br> 
## 🚧 Status
![Em Desenvolvimento](https://img.shields.io/badge/Status-Em%20Desenvolvimento-yellow?style=flat-square)

<br><br>
## 📝 DESCRIÇÃO
Destinos de viagens é uma API Restfull que realiza um CRUD nas entidades: Depoimento(Testimonial) e Destino(Destination) em um banco de dados MySql. 
Testa rotas Post, Get, Patch, Delete em testes de integrações com XUni e realiza integração com ChatGPT. 

➣ <b>Sobre entidades:</b> A entidade Depoimento(Testimonial) possui relacionamento 1:n com a tabela Cliente(Costumer), onde é possivel captar informações como 
a foto do usuario e nome para compor seu depoimento.  
➣ <b>Testes:</b> Os testes de integrações verificam os endpoints /testimonial e /destination<br>
➣ <b>Retornos de rotas:</b> a rota /testimonial-home retorna até 3 instâncias aleatórias do banco de dados 
➣ <b>Integração com o ChatGPT:</b> 
- caso a criação(post) de uma instância de destino contenha um campo de descrição como null, automaticamente esse campo será preenchido com uma resposta da IA. <br>
- Por consequencias de uma requisição gratuita ao ChatGPT, o prompt esta reduzido.

<br><br>
## 🛠️ FERRAMENTAS 
- C#
- MySql
- Ef Core
- AutoMapper
- HttpClient
- Postman
- Visual Studio
#### Conceitos aplicados:
- Camadas de Controller, Service, Repository, Model e DTO.
- População de dados automatica no banco de dados com <a href= "https://talented-gray-8e7.notion.site/Data-Seeds-c-a2cb553550c2400789337b2718d06bde?pvs=4">Seed Datas</a>
- Injeção de depêndencia
- Boas práticas de design e arquitetura 





<br><br><br>
## 👩‍💻 Autora
Larissa Leal 
<br><br>
[![Badge](https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/larissa-leal-dias-408455157/)

[![Medium Badge](https://img.shields.io/badge/Medium-%E2%97%BC%20black?style=for-the-badge&logo=medium&logoColor=white&color=black)]([URL_DO_SEU_LINK](https://medium.com/@larileal6)https://medium.com/@larileal6)
