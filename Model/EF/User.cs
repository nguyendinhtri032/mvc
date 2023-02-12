namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Net.Http;
    using System.Web.Mvc;
    public partial class User
    {
        [Key]
        [StringLength(20)]
        [Required]
        [Remote("IsUserNameExist", "Validation",  ErrorMessage = "Username already exists in database.")]

        public string UserName { get; set; }

        [Required]
        [StringLength(32)]
        public string Password { get; set; }

        [StringLength(32)]
        public string PasswordLevel2 { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string Mobile { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(50)]
        [Required]
        public string Address { get; set; }

        public bool Sex { get; set; }

        public decimal? Point { get; set; }

        [StringLength(50)]
        public string Token { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(20)]
        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [StringLength(20)]
        public string UpdatedBy { get; set; }

        public bool? IsLocked { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public DateTime? LastChangePassword { get; set; }
    }
}
