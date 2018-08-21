# Projeto Saude Vacina

**Sobre o projeto:**

- **Descrição:**
> Este é o meu projeto de conclusão do meu curso de especialização em desenvolvimento de aplicativos móveis. 

- **Convite:**
> Junte-se a mim neste projeto e vamos dar ferramentas à população para que todos possamos ter melhores condições de saúde

- **Link dos projetos:**
	- projetosaudevacina-ng: <ainda não publicado>
	- ProjetoSaudeVacina.API: http://projetosaudevacinaapi.azurewebsites.net/api/PostoSaude (ex.: get PostoSaude)
	- ProjetoSaudeVacina-Android: <ainda não publicado em loja>
	- ProjetoSaudeVacina-iOS: <ainda não publicado em loja>

**Características técnicas do projeto**

**Back-end:**
- C#

**API:**
- ASP.NET Core:
	- Automapper
	- Injeção de Dependências
	- Padrão de projeto Polimorfismo: repositories e services
	- DDD: Domain Driven Design (0 - Presentation, 1 - Application, 2 - Services, 3 - Domain, 4 - Infra)
	- Uso de DataValidations do asp.net core para verificar se os dados informados em post, put e delete estão corretos
	- Uso adequado dos verbos HTTP (API RestFull)
	- Uso de métodos da retorno disponibilizados pelo asp.net Ok(), BadRequest(), etc..
	- Herança entre entidades (implicando em herança no banco de dados, criação de discriminator, etc..)

**Front-end:**
- Web:
	- Angular (ngx-bootstrap, bootstrap)
- Mobile:
	- Android
	- iOS

########################################################################

**TODO LIST:**
- push notifications
> o cidadão pode se inscrever na lista de notificações para receber atualizações da vacinas e postos de seu interesse
- integration com google maps para o android e map kit para o ios
> exibir os postos de saúde no mapa e seus estoques
