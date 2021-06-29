using Core.Services;
using Data.Migration;
using Data.Repositories;
using Domain.Contracts.Repositories;
using Domain.Contracts.Services;
using Domain.Infra;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Controllers
{
    [ApiController]
    public class InfraController : ControllerBase
    {
        private readonly Random _random;

        private readonly ISkillRepository _skillRepository;
        private readonly ISkillService _skillService;

        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly IUserSkillRepository _userSkillRepository;

        private readonly IJobService _jobService;
        private readonly IJobRepository _jobRepository;
        private readonly IJobSkillRepository _jobSkillRepository;

        private readonly IJobInterviewRepository _jobInterviewRepository;
        private readonly IJobInterviewService _jobInterviewService;

        private readonly IJobFeedBackService _jobFeedBackService;
        private readonly IJobFeedBackRepository _jobFeedBackRepository;
        private readonly IJobFeedBackSkillRepository _jobFeedBackSkillRepository;

        private readonly IJobApplicantRepository _jobApplicantRepository;
        private readonly IJobApplicantService _jobApplicantService;

        private readonly ICompanyRepository _companyRepository;
        private readonly ICompanyService _companyService;

        public InfraController(
            ISkillRepository skillRepository,
            ISkillService skillService,

            IUserService userService,
            IUserRepository userRepository,
            IUserSkillRepository userSkillRepository,
            
            IJobService jobService,
            IJobRepository jobRepository,
            IJobSkillRepository jobSkillRepository,
            
            IJobInterviewRepository jobInterviewRepository,
            IJobInterviewService jobInterviewService,
            
            IJobFeedBackService jobFeedBackService,
            IJobFeedBackRepository jobFeedBackRepository,
            IJobFeedBackSkillRepository jobFeedBackSkillRepository,
            
            IJobApplicantRepository jobApplicantRepository,
            IJobApplicantService jobApplicantService,
            
            ICompanyRepository companyRepository,
            ICompanyService companyService
        )
        {
            _random = new Random();

            _skillRepository = skillRepository;
            _skillService = skillService;

            _userSkillRepository = userSkillRepository;
            _userRepository = userRepository;
            _userService = userService;

            _jobRepository = jobRepository;
            _jobService = jobService;
            _jobSkillRepository = jobSkillRepository;

            _jobInterviewRepository = jobInterviewRepository;
            _jobInterviewService = jobInterviewService;

            _jobFeedBackService = jobFeedBackService;
            _jobFeedBackRepository = jobFeedBackRepository;
            _jobFeedBackSkillRepository = jobFeedBackSkillRepository;

            _jobApplicantRepository = jobApplicantRepository;
            _jobApplicantService = jobApplicantService;

            _companyRepository = companyRepository;
            _companyService = companyService;
        }

        [HttpPost]
        [Route("api/Infra/Migration")]
        public ActionResult Migration([FromBody] Migration migration)
        {
            try
            {
                var migrationRun = new MigrationRun(migration);
                migrationRun.Execute();
                return Ok("Done!");
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        [HttpPost]
        [Route("api/Infra/Mock")]
        public ActionResult Mock()
        {
            try
            {
                LoadMockCompanys();
                LoadMockSkills();
                LoadMockUsers();
                LoadMockJobs();
                LoadJobApplicant();

                return Ok("Done!");
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        [HttpPost]
        [Route("api/Infra/MockInterview")]
        public ActionResult MockInterview()
        {
            try
            {
                LoadJobInterview();

                return Ok("Done!");
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        private void LoadMockCompanys()
        {

            int numberMaximumCompany = 2;

            foreach (var item in _companyRepository.GetAll())
            {
                _companyRepository.DeletePhysical(item.Id);
            }

            for (int i = 1; i <= numberMaximumCompany; i++)
            {
                var newCompany = new Company()
                {
                    Name = RamdomCompany(),
                    Description = RamdomDescription()

                };

                _companyService.Insert(newCompany);
            }

        }

        private void LoadMockSkills()
        {
            foreach (var item in _skillRepository.GetAll())
            {
                _skillRepository.DeletePhysical(item.Id);
            }

            string[] skills = {
                "Angular", "React", "Java Script", "Type Script",
                "HTML 5", "CSS/Sass", "Bootstrap",
                ".net C#", ".net Core",
                "Java", "PHP", "NodeJS", "Scrum", "Sql", "DevOps",
                "User Experience (UX)", "User Interface (UI)"
            };

            foreach (var name in skills)
            {
                _skillService.Insert(new Skill()
                {
                    Name = name
                });
            }
        }

        private void LoadMockUsers()
        {
            int numberMaximumUserSkill = 10;

            foreach (var item in _userRepository.GetAll())
            {
                _userSkillRepository.DeletePhysicalByRelacionalKey(item.Id);
                _userRepository.DeletePhysical(item.Id);
            }

            var skills = _skillRepository.GetAll();
            var companys = _companyRepository.GetAll();

            string[] maleFirstNames = {
                "Ricardo", "Fernando", "Danilo", "Guilherme", "Carlos", "Samuel", "Igor","Marcos","Augusto","Manuel",
                "Geraldo", "Gabriel", "Arthur", "Theo", "Davi", "Hugo", "Emanuel", "Lorenzo", "Benjamin", "Diogo"
             };

            string[] femaleFirstNames = {
                "Milena", "Laura", "Vanessa","Sophie", "Manuela", "Elisa", "Joana","Brenda", "Emanuelly", "Antonella",
                "Sueli", "Isabel", "Aline", "Julia","Helena", "Isabelle", "Maria", "Sarah", "Brenda", "Isis"
             };

            string[] middleNames = {
                "Silveira", "Moreira", "Farias", "Pietro", "Ribeiro",
                "Levi", "Gomes", "Pires", "Nair", "Costa",
                "Pinto", "Silva", "Severo", "Marques", "Santos"
            };

            string[] lastNames = {
                "da Costa", "da Mota", "de Paula", "da Cunha", "da Rocha",
                "da Mata", "Melo", "Duarte", "Aparecida", "Alves",
                "Teixeira", "Sales", "da Silva", "Campos","Moura"
            };

            for (int i = 1; i <= 20; i++)
            {
                bool isMale = i <= 10;

                var firstName = isMale
                    ? maleFirstNames[_random.Next(maleFirstNames.Length)]
                    : femaleFirstNames[_random.Next(femaleFirstNames.Length)];

                string name = string.Format("{0} {1} {2}",
                    firstName,
                    middleNames[_random.Next(middleNames.Length)],
                    lastNames[_random.Next(lastNames.Length)]);
                var selectedCompany = companys[_random.Next(companys.Count)];
                var newUser = new User()
                {
                    Image = string.Format("assets/img/users/{0}.jpg", i),
                    Name = name,
                    Description = RamdomDescription(),
                    Birthday = RamdomBirthday(),
                    Email = GenerateEmail(name),
                    Phone = RamdomPhone(),
                    Address = RamdomAddress(),
                    Type = GenerateUserType(),
                    CurrentPosition = RamdomPosition(),
                    CurrentWage = RamdomValue(),
                    Skills = new List<UserSkill>(),

                };
                if (newUser.Type != UserType.Unemployed)
                {
                    newUser.Category = GenerateUserCategory();
                    newUser.CurrentCompany = selectedCompany.Name;
                    newUser.IdCompany = selectedCompany.Id;
                } 
                else 
                { 
                    newUser.Category = UserCategory.Normal; 
                }
                for (int j = 0; j < _random.Next(6, numberMaximumUserSkill); j++)
                {
                    var idSkill = skills[_random.Next(skills.Count)].Id;

                    if (newUser.Skills.Any(x => x.IdSkill == idSkill))
                    {
                        j--;
                    }
                    else
                    {
                        newUser.Skills.Add(new UserSkill()
                        {
                            IdSkill = idSkill,
                            Ranking = _random.Next(2, 5)
                        });
                    }
                }

                _userService.Insert(newUser);
            }
        }

        private void LoadMockJobs()
        {
            int maximumNumberOfJobs = 20;
            int maximumNumberJobSkill = 10;

            foreach (var item in _jobRepository.GetAll())
            {
                _jobSkillRepository.DeletePhysicalByRelacionalKey(item.Id);
                _jobRepository.DeletePhysical(item.Id);
            }

            var skills = _skillRepository.GetAll();
            var companys = _companyRepository.GetAll();

            for (int i = 0; i < maximumNumberOfJobs; i++)
            {
                Level level = GenerateLevel();
                var selectedCompany = companys[_random.Next(companys.Count)];
                var newJob = new Job()
                {
                    
                    Name = string.Format("Desenvolvedor {0}", GetLevelName(level)),
                    Description = "Desenvolvimento de novas aplicação com foco no usuário.",
                    Level = level,
                    Remuneration = RamdomValue(),
                    IdCompany = (Int32)selectedCompany.Id,
                    Company = selectedCompany,
                    Skills = new List<JobSkill>()
                };

                var numberJobSkill = _random.Next(1, maximumNumberJobSkill);

                for (int j = 0; j < numberJobSkill; j++)
                {
                    var idSkill = skills[_random.Next(skills.Count)].Id;

                    if (newJob.Skills.Any(x => x.IdSkill == idSkill))
                    {
                        j--;
                    }
                    else
                    {
                        newJob.Skills.Add(new JobSkill()
                        {
                            IdSkill = idSkill,
                            Ranking = _random.Next(1, 5),
                            Weight = 100 / numberJobSkill
                        });
                    }
                }

                _jobService.Insert(newJob);
            }
        }

        private void LoadJobApplicant()
        {
            int numberJobApplicants = 20;

            var users = _userRepository.GetAll().Where(x => x.Type == UserType.Unemployed || x.Category == UserCategory.Normal).ToList();
            var jobs = _jobRepository.GetAll();

            for (int i = 0; i < numberJobApplicants; i++)
            {
                _jobApplicantRepository.Insert(new JobApplicant()
                {
                    IdApplicant = users[_random.Next(users.Count)].Id,
                    IdJob = jobs[_random.Next(jobs.Count)].Id,
                    SalaryClaim = RamdomValue()
                });
            }
        }

        private void LoadJobInterview()
        {
            int numberJobInterviews = 10;

            var jobApplicants = _jobApplicantService.GetAll();
            var jobApplicantsFiltred = jobApplicants.Where(x => x.Score <= 60).ToList();
            var RHs = _userService.GetAll().Where(x => x.Type == UserType.Employee && x.Category == UserCategory.HumanResources).ToList();
            var Technicals = _userService.GetAll().Where(x => x.Type == UserType.Employee && x.Category == UserCategory.Technical).ToList();

            for (int i = 0; i < numberJobInterviews; i++)
            {
                var jobApplicant = jobApplicantsFiltred[_random.Next(jobApplicantsFiltred.Count)];
                jobApplicant = _jobFeedBackRepository.GetAll().Where(x => x.IdJob == jobApplicant.IdJob && x.IdApplicant == jobApplicant.IdApplicant) == null ? jobApplicant : jobApplicant = jobApplicantsFiltred[_random.Next(jobApplicantsFiltred.Count)];
                var job = _jobService.GetAll().Where(x => x.Id == jobApplicant.IdJob).FirstOrDefault();
                var applicant = _userService.GetAll().Where(x => x.Id == jobApplicant.IdApplicant).FirstOrDefault();
                applicant.Skills = _userSkillRepository.GetAll().Where(x => x.IdUser == applicant.Id).ToList();
                var technical = Technicals.Where(x => x.IdCompany == job.IdCompany).FirstOrDefault();
                var RH = RHs.Where(x => x.IdCompany == job.IdCompany).FirstOrDefault();

                _jobFeedBackRepository.Insert(new JobFeedBack()
                {    
                    IdApplicant = applicant.Id,
                    IdJob = job.Id,
                    IdUserTecnical = technical.Id,
                    Recruiter = "Parecer do recrutador sobre a entrevista",
                    Technical = "Parecer do tecnico sobre a entrevista"

                });

                _jobInterviewRepository.Insert(new JobInterview()
                {
                    IdJobFeedBack = (int)_jobFeedBackRepository.GetAll().Last().Id,
                    IdJobApplicant = (int)applicant.Id,
                    IdUserRecruiter = (int)RH.Id,
                    IdUserTechnical = (int)technical.Id,
                    Date = job.RegistryDate.Value.AddDays(_random.Next(7, 20))
                });
                
                var idfeedback = _jobFeedBackService.GetAll().Last().Id;

                foreach (var jobSkill in job.Skills)
                {
                    var selfRank = applicant.Skills.Where(x => x.IdSkill == jobSkill.IdSkill).DefaultIfEmpty(new UserSkill { Ranking = 0 }).First().Ranking;
                    var jobRank = job.Skills.Where(x => x.IdSkill == jobSkill.IdSkill).First().Ranking;

                    _jobFeedBackSkillRepository.Insert(new JobFeedBackSkill()
                    {
                        IdApplicant = applicant.Id,
                        IdJobFeedBack = (int) idfeedback,
                        IdSkill = jobSkill.Id,
                        SelfEvaluation = selfRank,
                        TechnicalEvaluation = _random.Next(1, 5),
                        jobSkillRanking = jobRank,
                        Comment = "Avaliado pelo tecnico " + technical.Name + " por teste/questionario."
                    });
                }
            }
        }

        #region random data

        private string GenerateEmail(string name)
        {
            string nickName = name.Replace(" ", "").ToLower();
            string company;

            switch (_random.Next(2))
            {
                case 0:
                    company = "@gmail.com";
                    break;
                case 1:
                    company = "@outlook.com";
                    break;
                case 2:
                    company = "@yahoo.com";
                    break;

                default:
                    company = "@gmail.com";
                    break;
            }

            return string.Concat(nickName, company);
        }

        private UserCategory GenerateUserCategory()
        {
            switch (_random.Next(5))
            {
                case 1: return UserCategory.HumanResources;
                case 2: return UserCategory.Technical;
                default: return UserCategory.Normal;
            }
        }

        private UserType GenerateUserType()
        {
            switch (_random.Next(5))
            {
                case 1: return UserType.Unemployed;
                default: return UserType.Employee;
            }
        }

        private Level GenerateLevel()
        {
            switch (_random.Next(4))
            {
                case 0: return Level.Junior;
                case 1: return Level.Full;
                case 2: return Level.Senior;
                case 3: return Level.Trainee;
                default: return Level.Full;
            }
        }

        private string GetLevelName(Level level)
        {
            switch (level)
            {
                case Level.Junior: return "Júnior";
                case Level.Full: return "Pleno";
                case Level.Senior: return "Sênior";
                case Level.Trainee: return "Estagiário";
                default: return "Pleno";
            }
        }

        private string RamdomDescription()
        {
            string[] descriptions = {
                "Lorem Ipsum é simplesmente uma simulação de texto da indústria tipográfica e de impressos, e vem sendo utilizado desde o século XVI, quando um impressor desconhecido pegou uma bandeja de tipos e os embaralhou para fazer um livro de modelos de tipos. Lorem Ipsum sobreviveu não só a cinco séculos, como também ao salto para a editoração eletrônica, permanecendo essencialmente inalterado. Se popularizou na década de 60, quando a Letraset lançou decalques contendo passagens de Lorem Ipsum, e mais recentemente quando passou a ser integrado a softwares de editoração eletrônica como Aldus PageMaker.",
                "Ao contrário do que se acredita, Lorem Ipsum não é simplesmente um texto randômico. Com mais de 2000 anos, suas raízes podem ser encontradas em uma obra de literatura latina clássica datada de 45 AC. Richard McClintock, um professor de latim do Hampden-Sydney College na Virginia, pesquisou uma das mais obscuras palavras em latim, consectetur, oriunda de uma passagem de Lorem Ipsum, e, procurando por entre citações da palavra na literatura clássica, descobriu a sua indubitável origem. Lorem Ipsum vem das seções 1.10.32 e 1.10.33 do 'de Finibus Bonorum et Malorum' (Os Extremos do Bem e do Mal), de Cícero, escrito em 45 AC. Este livro é um tratado de teoria da ética muito popular na época da Renascença. A primeira linha de Lorem Ipsum, 'Lorem Ipsum dolor sit amet...' vem de uma linha na seção 1.10.32.",
                "É um fato conhecido de todos que um leitor se distrairá com o conteúdo de texto legível de uma página quando estiver examinando sua diagramação. A vantagem de usar Lorem Ipsum é que ele tem uma distribuição normal de letras, ao contrário de 'Conteúdo aqui, conteúdo aqui', fazendo com que ele tenha uma aparência similar a de um texto legível. Muitos softwares de publicação e editores de páginas na internet agora usam Lorem Ipsum como texto-modelo padrão, e uma rápida busca por 'lorem ipsum' mostra vários websites ainda em sua fase de construção. Várias versões novas surgiram ao longo dos anos, eventualmente por acidente, e às vezes de propósito (injetando humor, e coisas do gênero).",
                "Existem muitas variações disponíveis de passagens de Lorem Ipsum, mas a maioria sofreu algum tipo de alteração, seja por inserção de passagens com humor, ou palavras aleatórias que não parecem nem um pouco convincentes. Se você pretende usar uma passagem de Lorem Ipsum, precisa ter certeza de que não há algo embaraçoso escrito escondido no meio do texto. Todos os geradores de Lorem Ipsum na internet tendem a repetir pedaços predefinidos conforme necessário, fazendo deste o primeiro gerador de Lorem Ipsum autêntico da internet. Ele usa um dicionário com mais de 200 palavras em Latim combinado com um punhado de modelos de estrutura de frases para gerar um Lorem Ipsum com aparência razoável, livre de repetições, inserções de humor, palavras não características, etc.",
            };

            return descriptions[_random.Next(descriptions.Length)];
        }

        private DateTime RamdomBirthday()
        {
            return DateTime.Now.AddYears(-30).AddYears(_random.Next(10));
        }

        private double RamdomValue()
        {
            double value = _random.Next(1, 10) * 1000;

            switch (_random.Next(5))
            {
                case 0: return value *= 0.25;
                case 1: return value *= 0.5;
                case 2: return value *= 0.75;
                default: return value;
            }
        }

        private string RamdomPhone()
        {
            return string.Format("51 9{0}{1}{2}{3} {4}{5}{6}{7}",
                _random.Next(10),
                _random.Next(10),
                _random.Next(10),
                _random.Next(10),
                _random.Next(10),
                _random.Next(10),
                _random.Next(10),
                _random.Next(10));
        }

        private string RamdomAddress()
        {
            string[] address = {
                "Av. Alberto Bins",
                "Av. Borges de Medeiros",
                "Av. Desembargador André da Rocha",
                "Av. Independência",
                "Av. João Pessoa",
                "Av. Júlio de Castilhos",
                "Av. Loureiro da Silva",
                "Av. Mauá",
                "Rua Coronel Genuíno",
                "Rua Coronel Vicente",
                "Rua dos Andradas",
                "Rua Doutor Flores",
                "Rua Duque de Caxias",
            };

            return string.Format("{0}, {1} - Centro - Porto Alegre/RS", address[_random.Next(address.Length)], _random.Next(000, 9999).ToString());
        }

        private string RamdomPosition()
        {
            switch (_random.Next(4))
            {
                case 0: return "Desenvolvedor frontend";
                case 1: return "Desenvolvedor backend";
                default: return "Desenvolvedor full stack";
            }
        }

        private string RamdomCompany()
        {
            switch (_random.Next(5))
            {
                case 0: return "Empresa Azul";
                case 1: return "Empresa Verde";
                case 2: return "Empresa Vermelho";
                case 3: return "Empresa Branco";
                default: return "Empresa Preto";
            }
        }

        #endregion
    }
}
