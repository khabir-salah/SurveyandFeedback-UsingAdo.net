using SurveyAdo.Infracstructure.Context;
using SurveyAdo.Presentation;
var startup = new StartUp();
startup.CreateConnection();
// startup.CreateDataBase();
// startup.createSurveyTable();
// startup.createFeedbackTAble();
// startup.createRegisteredTable();
// startup.createUnRegisteredTable();

Main mainMenu = new Main();
mainMenu.Menu();

