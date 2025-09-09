using Speccon.Learnership.FrontEnd.Models.Common;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace Speccon.Learnership.FrontEnd.Models.Users
{
    public class UserDto
    {
        public int UserId { get; set; }
        public Guid UserKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public DateTime Birthdate { get; set; }
        public int Gender_ID { get; set; }
        public int Demographic_ID { get; set; }
        public int Manager_User_ID { get; set; }
        public int Job_Title_ID { get; set; }
        public bool Disabled { get; set; }
        public int DisabilityID { get; set; }
        public bool Disabled_proof { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int Country_ID { get; set; }
        public int Address_ID { get; set; }
        public string? ID_number { get; set; }
        public int Home_Language_ID { get; set; }
        public int Second_Language_ID { get; set; }
        public string? Contact_No { get; set; }
        public string? Facebook_Link { get; set; }
        public string? Instagram_Link { get; set; }
        public string? Linkedin_Link { get; set; }
        public string? X_Link { get; set; }
        public string? Profile_Picture { get; set; }
        public int User_Role_ID { get; set; }
        public int Client_ID { get; set; }
        public bool Email_Confirmed { get; set; }
        public bool Manager_Approved { get; set; }
        public bool IsEmployed { get; set; }
        public string? Company_Employed { get; set; }
        public bool Is_Manager { get; set; }
        public bool Is_Admin { get; set; }
        public bool Is_Super_Admin { get; set; }
        public bool Is_SDF { get; set; }
        public bool IsMigratedUser { get; set; }
        public string? Marketing_Source { get; set; }
        public string? Address { get; set; }
        public Guid LmsKey { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public bool IsSubscription { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }

    public class UserReportDto
    {
        public int UserId { get; set; }
        public Guid UserKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public int GenderId { get; set; }
        public int DemographicId { get; set; }
        public int ManagerUserId { get; set; }
        public int JobTitleId { get; set; }
        public bool Disabled { get; set; }
        public int DisabilityId { get; set; }
        public bool DisabledProof { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int CountryId { get; set; }
        public int AddressId { get; set; }
        public string? IdNumber { get; set; }
        public int HomeLanguageId { get; set; }
        public int SecondLanguageId { get; set; }
        public string? ContactNo { get; set; }
        public string? FacebookLink { get; set; }
        public string? InstagramLink { get; set; }
        public string? LinkedinLink { get; set; }
        public string? ProfilePicture { get; set; }
        public int UserRoleId { get; set; }
        public int ClientId { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool ManagerApproved { get; set; }
        public bool IsEmployed { get; set; }
        public string? CompanyEmployed { get; set; }
        public bool IsManager { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsSuperAdmin { get; set; }
        public bool IsSDF { get; set; }
        public string? MarketingSource { get; set; }
        public int JobTitleJdId { get; set; }
        public string? CareerVision { get; set; }
        public string? CareerObjectives { get; set; }
        public string? Ethnicity { get; set; }
        public bool EnabledInfoSharing { get; set; }
        public bool IsAlreadyLoggedIn { get; set; }
        public string? AboutSelf { get; set; }
        public string? TwitterLink { get; set; }
        public bool HasDrivingLicence { get; set; }
        public Guid LmsKey { get; set; }
        public int SubscriptionPackageTypeId { get; set; }
        public string? SubscriptionPackageTypeDescription { get; set; }
        public int RegistrationTypeId { get; set; }
        public string? EmployeeNumber { get; set; }
        public string? Branch { get; set; }
        public string? BusinessUnit { get; set; }
        public string? Department { get; set; }
        public string? DirectSupervisor { get; set; }
        public bool IsMigratedUser { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? PassportNumber { get; set; }
        public string? ReferenceNo { get; set; }
        public string? Referral { get; set; }
        public bool IsSubscription { get; set; }
        public DateTime? LastLogin { get; set; }
        public UserAddress? UserAddress { get; set; }
        public UserRole? UserRole { get; set; }
    }

    public class UserAddress
    {
        [Key]
        public int UserAddressId { get; set; }
        public Guid UserAddressKey { get; set; } = Guid.NewGuid();
        public string? StreetAddress { get; set; } = string.Empty;
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public int ProvinceId { get; set; }
        public int CountryId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int RecordStatusId { get; set; } = Constants.ActiveRecordStatusId;
        public decimal LatitudeDecimal { get; set; }
        public decimal LongitudeDecimal { get; set; }
    }

    public class UserRole
    {
        [Key]
        public int UserRoleId { get; set; }
        public Guid UserRoleKey { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? RoleDescription { get; set; } = string.Empty;
        public int RecordStatusId { get; set; } = Constants.ActiveRecordStatusId;
    }

    public class CreateUserDto
    {
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public DateTime Birthdate { get; set; }
        public int Gender_ID { get; set; }
        public int Demographic_ID { get; set; }
        public int Manager_User_ID { get; set; }
        public int Job_Title_ID { get; set; }
        public bool Disabled { get; set; }
        public int DisabilityID { get; set; }
        public bool Disabled_proof { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int Country_ID { get; set; }
        public int Address_ID { get; set; }
        public string? ID_number { get; set; }
        public int Home_Language_ID { get; set; }
        public int Second_Language_ID { get; set; }
        public string? Contact_No { get; set; }
        public string? Facebook_Link { get; set; }
        public string? Instagram_Link { get; set; }
        public string? Linkedin_Link { get; set; }
        public string? Profile_Picture { get; set; }
        public int User_Role_ID { get; set; }
        public int Client_ID { get; set; }
        public bool Email_Confirmed { get; set; }
        public bool Manager_Approved { get; set; }
        public bool IsEmployed { get; set; }
        public string? Company_Employed { get; set; }
        public bool Is_Manager { get; set; }
        public bool Is_Admin { get; set; }
        public bool Is_Super_Admin { get; set; }
        public bool Is_SDF { get; set; }
        public string? Marketing_Source { get; set; }
        public Guid LmsKey { get; set; } = Guid.NewGuid();
    }

    public class EditUserDto
    {
        public Guid UserKey { get; set; }
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime CreateDate { get; set; }
        public int GenderId { get; set; }
        public int DemographicId { get; set; }
        public int ManagerUserId { get; set; }
        public int JobTitleId { get; set; }
        public bool Disabled { get; set; }
        public int DisabilityId { get; set; }
        public bool Disabled_proof { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int CountryId { get; set; }
        public int AddressId { get; set; }
        public string? Address { get; set; }
        public string? IdNumber { get; set; }
        public int HomeLanguageId { get; set; }
        public int SecondLanguageId { get; set; }
        public string? ContactNo { get; set; }
        public string? XLink { get; set; }
        public string? FacebookLink { get; set; }
        public string? InstagramLink { get; set; }
        public string? LinkedinLink { get; set; }
        public string? ProfilePicture { get; set; }
        public int UserRoleId { get; set; }
        public int ClientId { get; set; }
        public bool EmailConfirmed { get; set; }
      
        public bool IsEmployed { get; set; }
        public string? CompanyEmployed { get; set; }
        public bool IsManager { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsSuperAdmin { get; set; }
        public bool IsSDF { get; set; }
        public string? MarketingSource { get; set; }
        public string? CareerVision { get; set; }
        public string? CareerObjectives { get; set; }
        public string? Ethnicity { get; set; }
        public bool EnabledInfoSharing { get; set; }
        public bool IsAlreadyLoggedIn { get; set; }
        public string? AboutSelf { get; set; }
        public string? TwitterLink { get; set; }
        public bool HasDrivingLicence { get; set; }
        public Guid LmsKey { get; set; }
        public int SubscriptionPackageTypeId { get; set; }
        public int RegistrationTypeId { get; set; }
        public string? EmployeeNumber { get; set; }
        public string? Branch { get; set; }
        public string? BusinessUnit { get; set; }
        public string? Department { get; set; }
        public string? DirectSupervisor { get; set; }
        public bool IsMigratedUser { get; set; }
        public bool IsSubscription { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
    }
}
