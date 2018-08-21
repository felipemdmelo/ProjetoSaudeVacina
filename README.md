# Projeto Saude Vacina

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
