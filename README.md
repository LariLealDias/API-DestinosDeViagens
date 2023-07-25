# API-DestinosDeViagens
API Restfull em C#

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
➣ <b>Integração com o ChatGPT:</b> caso a criação(post) de uma instância de destino contenha um campo de descrição como null, automaticamente esse campo será preenchido com uma resposta da IA. <br>
➣ <b>Retornos de rotas:</b> a rota /testimonial-home retorna até 3 instâncias aleatórias do banco de dados 

<br><br>
## 🛠️ FERRAMENTAS 
- C#
- MySql
- Ef Core
- AutoMapper
- Postman
- Visual Studio
#### Conceitos aplicados:
- Camadas de Controller, Service, Repository, Model e DTO.
- População de dados automatica no banco de dados com Seed Datas
- Injeção de depêndencia
- Boas práticas de design e arquitetura 





<br><br><br>
## 👩‍💻 Autora
Larissa Leal 
<br><br>
[![Badge](https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/larissa-leal-dias-408455157/)

