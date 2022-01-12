namespace MVC.EditUserInfoFormModelCentric.Domain
{
    public class UserInfoService
    {
        private UserInfoDTO _userInfoDTO;

        public UserInfoService()
        {
            _userInfoDTO = new UserInfoDTO
            {
                FirstName = "Yauheni",
                LastName = "But-Husaim"
            };
        }

        public UserInfoDTO Get()
        {
            return _userInfoDTO;
        }

        public void Save(UserInfoDTO userInfoDTO)
        {
            _userInfoDTO = userInfoDTO;
        }
    }
}
