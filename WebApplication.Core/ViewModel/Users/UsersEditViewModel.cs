using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Core.ViewModel.Users
{
    /// <summary>
    /// جدول کاربران
    /// </summary>
    public class UsersEditViewModel
    {
        /// <summary>
        /// کلید اصلی
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// نام
        /// </summary>
        [Display(Name = "نام")]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// نام خانوادگی
        /// </summary>
        [Display(Name = "نام خانوادگی")]
        [StringLength(50)]
        public string Family { get; set; }

        /// <summary>
        /// نام کامل
        /// </summary>
        [Display(Name = "نام کامل")]
        [StringLength(101)]
        public string FullName { get; set; }

        /// <summary>
        /// نام کاربری
        /// </summary>
        [Display(Name = "نام کاربری")]
        [StringLength(20)]
        public string UserName { get; set; }

        /// <summary>
        /// کلمه عبور
        /// </summary>
        [Display(Name = "کلمه عبور")]
        [StringLength(20)]
        public string Password { get; set; }

        /// <summary>
        /// تصویر کاربر
        /// </summary>
        [Display(Name = "تصویر کاربر")]
        [StringLength(200)]
        public string Avatar { get; set; }

        /// <summary>
        /// فعال
        /// </summary>
        [Display(Name = "فعال")]
        public bool IsActive { get; set; }

        /// <summary>
        /// تغییر اطلاعات کاربر
        /// </summary>
        [Display(Name = "تغییر اطلاعات کاربر")]
        public bool ChangeProfile { get; set; }

        /// <summary>
        /// تاریخ ایجاد
        /// </summary>
        [Display(Name = "تاریخ ایجاد")]
        [StringLength(10)]
        public string CreationDate { get; set; }

        /// <summary>
        /// تاریخ ویرایش
        /// </summary>
        [Display(Name = "تاریخ ویرایش")]
        [StringLength(10)]
        public string EditDate { get; set; }
    }
}