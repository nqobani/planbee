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
        public Project addProject(string projectName, int userID, string description)
        {
            return logicBlaBlaBla.addProject(projectName, userID, description);
        }

        [Route("api/add/meetings")]
        public Meeting addMeeting(int projectID, string meetingName, string notes, string decisions, string imagePath = null)
        {
           //// if(imagePath!=null)
           //     return logicBlaBlaBla.insertMeeting(projectID, meetingName, notes, decisions, System.Text.Encoding.UTF8.GetBytes(imagePath.imageData));

            return logicBlaBlaBla.insertMeeting(projectID, meetingName, notes, decisions, imagePath);
        }

    
        [Route("api/register/user")]
        public async System.Threading.Tasks.Task<User> addUserAsync(string username, string email, string password, string confirmPassword)
        {
            if (!password.Equals(confirmPassword))
            {
                return null;
            }

            return await logicBlaBlaBla.addUserAsync(username, email, password, confirmPassword);
        }
        [Route("api/register/confirmation")]
        public User confirmUserRegistration(int userId, int confirmationCode)
        {
            return logicBlaBlaBla.confirmUserRegistration(userId, confirmationCode);
        }


        [Route("api/user/resertPassword")]
        public User resertPassoword(string usernameOrEmail, string newPassword, string confirmPassword)
        {
            if (!newPassword.Equals(confirmPassword))
            {
                return null;
            }

            var user = logicBlaBlaBla.resertPasswordEmail(usernameOrEmail, newPassword);

            if(user == null)
                user = logicBlaBlaBla.resertPasswordUsername(usernameOrEmail, newPassword);

            return user;



        }

        [Route("api/update/meetings")]
        public Meeting addMeeting(int id, int projectID = -1, string meetingName = null, string notes = null, string decisions = null)
        {
            return logicBlaBlaBla.updateMeeting(id, projectID, meetingName, notes, decisions);
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

        [Route("api/get/userByUsernameOrEmail")]
        public User getUserByUsernameOrEmail(string usernameOrEmail)
        {
            return logicBlaBlaBla.getUserByUsernameOrPassword(usernameOrEmail);
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

        [Route("api/project/share")]
        public SharedProjects shareProject(int sharedBy, int sharedTo, int projectId)
        {
            return logicBlaBlaBla.ShareProject(sharedBy, sharedTo, projectId);
        }

        [Route("api/meetings/share")]
        public SharedMeetings shareMeetings(int sharedBy, int sharedTo, int meetingId)
        {
            return logicBlaBlaBla.ShareMeetings(sharedBy, sharedTo, meetingId);
        }

        [Route("api/get/sharedmeetings")]
        public List<Meeting> getSharedMeetings(int userId)
        {
            return logicBlaBlaBla.getSharedMeetings(userId);
        }
        [Route("api/get/sharedprojects")]
        public List<Project> getSharedProject(int userId)
        {
            return logicBlaBlaBla.getSharedProjects(userId);
        }

        [Route("api/get/hasProject")]
        public SharedProjects hasProject(int sharedTo, int projectId)
        {
            return logicBlaBlaBla.hasProject(sharedTo, projectId);
        }
        [Route("api/get/hasMeeting")]
        public SharedMeetings hasMeeting(int sharedTo, int meetingId)
        {
            return logicBlaBlaBla.hasMeeting(sharedTo, meetingId);
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

        [Route("api/meeting/delete")]
        public bool deleteMeeting(int meetingId)
        {
            return logicBlaBlaBla.deleteMeeting(meetingId);
        }

        [Route("api/project/delete")]
        public bool deleteProject(int projectId)
        {
            return logicBlaBlaBla.deleteProject(projectId);
        }
    }
}
