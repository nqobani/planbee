using DMNS.LogicLayer;
using DMNS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DMNS.Controllers
{
    [SerializableAttribute]
    public class ValuesController : ApiController
    {
        LogicBlaBlaBla logicBlaBlaBla = new LogicBlaBlaBla();
        [Route("api/add/project")]
        public Project addProject(string projectName, int userID)
        {
            return logicBlaBlaBla.addProject(projectName, userID);
        }
        [Route("api/add/meetings")]
        public Meeting addMeeting(int projectID, string meetingName, string notes, string decisions)
        {
            return logicBlaBlaBla.insertMeeting(projectID, meetingName, notes, decisions);
        }
        [Route("api/register/user")]
        public User addUser(string username, string email, string password, string confirmPassword)
        {
            return logicBlaBlaBla.addUser(username, email, password, confirmPassword);
        }
        [Route("api/get/project")]
        public Project getProjects(int id)
        {
            return logicBlaBlaBla.getProject(id);
        }

        [Route("api/get/meting")]
        public Meeting getMeetings(int id)
        {
            return logicBlaBlaBla.getMeeting(id);
        }
        [Route("api/get/login")]
        public User getAllUsers(string username, string password)
        {
            
            return logicBlaBlaBla.getUser(username, password);
        }

        [Route("api/get/user/projects")]
        public List<Project> getUserProjects(int userId)
        {
            return logicBlaBlaBla.getUserProjects(userId);
        }

        [Route("api/get/project/metings")]
        public List<Meeting> getProjectMeetings(int projectId)
        {
            return logicBlaBlaBla.getProjectMeetings(projectId);
        }



        [Route("api/get/all/users")]
        public List<User> getAllUsers()
        {
            var x = logicBlaBlaBla.getAllUsers();
            return x;
        }
        [Route("api/get/all/projects")]
        public List<Project> getAllProjects()
        {
            return logicBlaBlaBla.getAllProjects();
        }
        [Route("api/get/all/metings")]
        public List<Meeting> getMeetings()
        {
            return logicBlaBlaBla.getAllMeetings();
        }
    }
}
