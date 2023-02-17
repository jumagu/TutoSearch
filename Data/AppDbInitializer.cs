using Microsoft.AspNetCore.Identity;
using TutoSearch.Data.Static;
using TutoSearch.Models;

namespace TutoSearch.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                //Professors
                if (!context.Professor.Any())
                {
                    context.Professor.AddRange(new List<Professor>()
                    {
                        new Professor()
                        {
                            FullName = "Jhonattan Báez",
                            ProfilePictureURL = "http://localhost/img/tutosearch/professors/jhonattanbaez.jpg",
                            Bio = "Jhonattan Báez, conocido como Quimiayudas, es un químico, profesor y youtuber de origen colombiano, conocido actualmente por sus vídeos de Química."
                        },
                        new Professor()
                        {
                            FullName = "Alexander Gómez",
                            ProfilePictureURL = "http://localhost/img/tutosearch/professors/alexandergomez.jpg",
                            Bio = "Alexander Gómez, conocido en línea como Matemáticas profe Alex, es un profesor y youtuber colombiano que sube vídeos de matemáticas. Es licenciado en Matemáticas y Estadística de la Universidad Pedagógica y Tecnológica de Colombia."
                        },
                        new Professor()
                        {
                            FullName = "Julio Ríos",
                            ProfilePictureURL = "http://localhost/img/tutosearch/professors/juliorios.jpg",
                            Bio = "Julio Alberto Ríos Gallego (Cali, 22 de marzo de 1973), conocido como julioprofe, es un ingeniero civil, profesor, matemático, físico, conferencista, tutor y youtuber colombiano."
                        },
                        new Professor()
                        {
                            FullName = "Henry Martinez",
                            ProfilePictureURL = "http://localhost/img/tutosearch/professors/henrymartinez.png",
                            Bio = "Henry Martinez Carmona es un ingeniero mecánico colombiano, tiene un canal de YouTube llamado Física para todos en donde publica vídeos sobre temas sobre algunas áreas de la física como como la cinemática, estatica, dinámica, estática, termodinámica y electricidad, etc."
                        },
                        new Professor()
                        {
                            FullName = "David Calle",
                            ProfilePictureURL = "http://localhost/img/tutosearch/professors/davidcalle.jpg",
                            Bio = "David Calle Parrilla (Coslada, Madrid, 15 de diciembre de 1972), también conocido como Unicoos, es un ingeniero de telecomunicaciones, profesor y youtuber español, fundador de la página web Unicoos. Es licenciado por la Universidad Politécnica de Madrid. Primeramente trabajó en Xfera, la operadora de móviles conocida con el nombre de Yoigo."
                        }
                    });
                    context.SaveChanges();
                }

                //Topics
                if (!context.Topic.Any())
                {
                    context.Topic.AddRange(new List<Topic>()
                    {
                        new Topic()
                        {
                            Name = "Estequiometría",
                            Description = "En química, la estequiometría es el cálculo de las relaciones cuantitativas entre los reactivos y productos en el transcurso de una reacción química.",
                            TopicSubject = Enum.TopicSubject.Chemistry
                        },
                        new Topic()
                        {
                            Name = "Circunferencia",
                            Description = "La circunferencia es el lugar geométrico de los puntos del plano que equidistan de un punto fijo llamado centro.",
                            TopicSubject = Enum.TopicSubject.Maths
                        },
                        new Topic()
                        {
                            Name = "Primera Ley de Newton",
                            Description = "La primera ley del movimiento rebate la idea aristotélica de que un cuerpo solo puede mantenerse en movimiento si se le aplica una fuerza. Esta ley postula, por tanto, que un cuerpo no puede cambiar por sí solo su estado inicial, ya sea en reposo o en movimiento rectilíneo uniforme, a menos que se aplique una fuerza o una serie de fuerzas cuya resultante no sea nula.",
                            TopicSubject = Enum.TopicSubject.MechanicalPhysics
                        },
                        new Topic()
                        {
                            Name = "Integración",
                            Description = "La integración es un concepto fundamental del cálculo y del análisis matemático. Básicamente, una integral es una generalización de la suma de infinitos sumandos, infinitesimalmente pequeños: una suma continua. La integral es la operación inversa a la diferencial de una función",
                            TopicSubject = Enum.TopicSubject.IntegralCalculus
                        },
                        new Topic()
                        {
                            Name = "Integración por partes",
                            Description = "A diferencia de las derivadas, no existe una fórmula para poder integrar cualquier producto de funciones. Sin embargo, la integración por partes transforma una integral de un producto en otra integral. Esta fórmula no funciona para integrar todos los productos de funciones.",
                            TopicSubject = Enum.TopicSubject.IntegralCalculus
                        },
                        new Topic()
                        {
                            Name = "Integración por fracciones parciales",
                            Description = "Las fracciones parciales es un método de integración que permite resolver integrales de ciertas funciones racionales que no se pueden resolver por los otros métodos (formula directa, por partes, cambio de variable, etc.) ",
                            TopicSubject = Enum.TopicSubject.IntegralCalculus
                        },
                        new Topic()
                        {
                            Name = "Medidas de Tendencia Central",
                            Description = "Las medidas de tendencia central son medidas estadísticas que pretenden resumir en un solo valor a un conjunto de valores. Representan un centro en torno al cual se encuentra ubicado el conjunto de los datos. Las medidas de tendencia central más utilizadas son: media, mediana y moda.",
                            TopicSubject = Enum.TopicSubject.Statistics
                        },
                        new Topic()
                        {
                            Name = "Medidas de Variabilidad",
                            Description = "En estadística, las medidas de dispersión (también llamadas variabilidad, dispersión o propagación) es el grado en que una distribución se estira o se comprime. Ejemplos comunes de medidas de dispersión estadística son la varianza, la desviación estándar y el rango intercuartil.",
                            TopicSubject = Enum.TopicSubject.Statistics
                        }
                    });
                    context.SaveChanges();
                }

                //BasicLesson
                if (!context.BasicLesson.Any())
                {
                    context.BasicLesson.AddRange(new List<BasicLesson>()
                    {
                        new BasicLesson()
                        {
                            Title = "Estequiometría: Calculos con reactivo limite y en exceso (gramos)",
                            Description = "Aqui encontraras la mejor explicación de un ejercicio en el que se calculan cantidades de reacción teniendo en cuenta el reactivo limite y exceso en gramos.",
                            VideoURL = "http://localhost/img/tutosearch/basiclessons/stoichiometrylimitreagent.mp4",
                            ProfessorId = 1,
                        },
                        new BasicLesson()
                        {
                            Title = "Conceptos básicos ecuación de la CIRCUNFERENCIA",
                            Description = "Explicación de los conceptos básicos de la circunferencia, centro, radio y ecuación canónica, dentro del curso de ecuación de la recta.",
                            VideoURL = "http://localhost/img/tutosearch/basiclessons/circunferenciabasicos.mp4",
                            ProfessorId = 2,
                        },
                        new BasicLesson()
                        {
                            Title = "Explicación Primera Ley de Newton",
                            Description = "Explicación básica e introductoria a la Primera Ley de Newton.",
                            VideoURL = "http://localhost/img/tutosearch/basiclessons/primeraleynewton.mp4",
                            ProfessorId = 3,
                        },
                        new BasicLesson()
                        {
                            Title = "INTEGRACIÓN POR PARTES",
                            Description = "En este video veremos un ejemplo resuelto mediante integración por partes, de Ln(x) entre x al cuadrado, paso a paso.",
                            VideoURL = "http://localhost/img/tutosearch/basiclessons/integralporpartes.mp4",
                            ProfessorId = 3,
                        },
                        new BasicLesson()
                        {
                            Title = "Interpretar las medidas de tendencia central | Media, Mediana y Moda",
                            Description = "Explicación de una forma de interpretar las medidas de tendencia central: Media, Mediana y Moda, es decir cómo dar las conclusiones de los datos cuando conocemos la media la mediana y la moda, dentro del curso de Media, mediana y moda.",
                            VideoURL = "http://localhost/img/tutosearch/basiclessons/medidascentralinterp.mp4",
                            ProfessorId = 2,
                        },
                    });
                    context.SaveChanges();
                }

                //ExpertLesson
                if (!context.ExpertLesson.Any())
                {
                    context.ExpertLesson.AddRange(new List<ExpertLesson>()
                    {
                        new ExpertLesson()
                        {
                            Title = "Estequiometría: Cálculos mol-mol",
                            Description = "Aquí encontraras la mejor explicación de un ejercicio en el que se calculan cantidades de reacción, con unidades de mol a mol.",
                            VideoURL = "http://localhost/img/tutosearch/expertlessons/stoichiometrymolmol.mp4",
                            ProfessorId = 1,
                            Price = 1.99
                        },
                        new ExpertLesson()
                        {
                            Title = "Hallar la ecuacion general de la CIRCUNFERENCIA conociendo el centro y el radio",
                            Description = " Explicación de cómo encontrar la ecuación general de la circunferencia cuando conocemos el centro y el radio.",
                            VideoURL = "http://localhost/img/tutosearch/expertlessons/circunferenciaexpert.mp4",
                            ProfessorId = 2,
                            Price = 2.99
                        },
                        new ExpertLesson()
                        {
                            Title = "Cómo calcular la tensión de las cuerdas - 1ra Ley de Newton",
                            Description = "En este vídeo se explica un ejercicio donde se requiere calcular la tensión de las cuerdas de una masa suspendida aplicando la 1ra Ley de Newton (ejercicio de estática).",
                            VideoURL = "http://localhost/img/tutosearch/expertlessons/ejercicioprimeraleynewton.mp4",
                            ProfessorId = 4,
                            Price = 2.49
                        },
                        new ExpertLesson()
                        {
                            Title = "INTEGRACIÓN POR FRACCIONES PARCIALES",
                            Description = "En este video veremos un ejemplo resuelto mediante integración por fracciones parciales, paso a paso.",
                            VideoURL = "http://localhost/img/tutosearch/expertlessons/intefracparciales.mp4",
                            ProfessorId = 3,
                            Price = 1.99
                        },
                        new ExpertLesson()
                        {
                            Title = "Estadística - Datos agrupados SECUNDARIA",
                            Description = "En esta tutoría se desarrollará un ejercicio de ESTADÍSTICA a partir de una muestra de 11 datos distribuidos en INTERVALOS. Hallaremos el intervalo Modal, la Mediana, frecuencias absolutas y relativas,Moda, Media, Desviación Típica, Varianza y varios Percentiles y Cuartiles.",
                            VideoURL = "http://localhost/img/tutosearch/expertlessons/datosagrupados.mp4",
                            ProfessorId = 5,
                            Price = 3.99
                        }
                    });
                    context.SaveChanges();
                }

                //Lessons
                /* if (!context.Lesson.Any())
                {
                    context.Lesson.AddRange(new List<Lesson>()
                    {
                        new Lesson()
                        {
                            Title = "",
                            Description = "",
                            VideoURL = "",
                            ProfessorId = 0,
                        }
                    });
                } */

                //Topics_Lessons
                if (!context.Topic_Lesson.Any())
                {
                    context.Topic_Lesson.AddRange(new List<Topic_Lesson>()
                    {
                        new Topic_Lesson()
                        {
                            TopicId = 1,
                            LessonId = 1
                        },
                        new Topic_Lesson()
                        {
                            TopicId = 2,
                            LessonId = 2
                        },
                        new Topic_Lesson()
                        {
                            TopicId = 3,
                            LessonId = 3
                        },
                        new Topic_Lesson()
                        {
                            TopicId = 4,
                            LessonId = 4
                        },
                        new Topic_Lesson()
                        {
                            TopicId = 5,
                            LessonId = 4
                        },
                        new Topic_Lesson()
                        {
                            TopicId = 7,
                            LessonId = 5
                        },
                        new Topic_Lesson()
                        {
                            TopicId = 1,
                            LessonId = 6
                        },
                        new Topic_Lesson()
                        {
                            TopicId = 2,
                            LessonId = 7
                        },
                        new Topic_Lesson()
                        {
                            TopicId = 3,
                            LessonId = 8
                        },
                        new Topic_Lesson()
                        {
                            TopicId = 4,
                            LessonId = 9
                        },
                        new Topic_Lesson()
                        {
                            TopicId = 6,
                            LessonId = 9
                        },
                        new Topic_Lesson()
                        {
                            TopicId = 7,
                            LessonId = 10
                        },
                        new Topic_Lesson()
                        {
                            TopicId = 8,
                            LessonId = 10
                        },
                    });
                    context.SaveChanges();
                }
            }
        }
        
        public static async Task SeedUserAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {    
                var services = serviceScope.ServiceProvider;
                var context = services.GetRequiredService<ApplicationDbContext>();

                // Roles
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                if (await roleManager.FindByNameAsync(UserRoles.Admin) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                }
                if (await roleManager.FindByNameAsync(UserRoles.User) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                }

                //Users
                string password = "Tut0.s34rch";
                var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
                
                string email = "juanm.gutierrezg@usantoto.edu.co";
                if (await userManager.FindByNameAsync(email) == null)
                {
                    var user = new IdentityUser()
                    {
                        UserName = email,
                        Email = email,
                        PhoneNumber = "54321",
                        EmailConfirmed = true,
                    };
                    var result = await userManager.CreateAsync(user);
                    if (result.Succeeded)
                    {
                        await userManager.AddPasswordAsync(user, password);
                        await userManager.AddToRoleAsync(user, UserRoles.Admin);
                    }
                }

                email = "jmgg.gutierrez@gmail.com";
                if (await userManager.FindByNameAsync(email) == null)
                {
                    var user = new IdentityUser()
                    {
                        UserName = email,
                        Email = email,
                        PhoneNumber = "54321",
                        EmailConfirmed = true,
                    };
                    var result = await userManager.CreateAsync(user);
                    if (result.Succeeded)
                    {
                        await userManager.AddPasswordAsync(user, password);
                        await userManager.AddToRoleAsync(user, UserRoles.User);
                    }
                }
            }
        }
    }
}
