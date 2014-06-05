﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PTO.Core.Config;
using PTO.Core.Entities;

namespace PTO.Entity.Email
{
    /// <summary>
    /// Representation of an email to be generated by a Razor template
    /// </summary>
    public class Email : AuditEntity<Email, long>
    {
        protected Email()
        {
            Recipients = new List<Recipient>();
            FromAddress = AppConfig.Current.Email.FromAddress;
            Status = EmailSendStatus.Pending;
            if (EmailGuid == Guid.Empty)
            {
                EmailGuid = Guid.NewGuid();
            }
        }

        public Email(TemplateType templateType)
            : this()
        {
            TemplateType = templateType;
        }

        [Required]
        public string FromAddress { get; set; }

        [Required]
        public virtual IList<Recipient> Recipients { get; set; }

        [Required]
        public virtual TemplateType TemplateType { get; set; }

        [Required]
        public string Subject { get; set; }

        public bool IsGenerated { get; set; }

        public virtual EmailSendStatus Status { get; set; }

        public bool IsSolicited { get; set; }

        public DateTime? DateSent { get; set; }

        public short NumberOfSendAttempts { get; set; }

        public int NumberOfSuccessfulAttempts { get; set; }

        public string LastSendError { get; set; }

        /// <summary>
        /// The Body properties are generated once as output from the current active template
        ///  associated to the email's TemplateType
        /// </summary>
        public string HtmlBody { get; set; }
        public string TextBody { get; set; }

        /// <summary>
        /// Unique identifier used to track emails and manage unsubscribing, etc.
        /// </summary>
        public Guid EmailGuid { get; set; }

        /// <summary>
        /// This property is NOT used to determine which template to use to generate
        ///  it is used to record which template was used historically.
        /// The template type is used to find the current active template, 
        ///  which is then used to generate the email bodies
        /// </summary>
        public virtual Template TemplateUsedToGenerate { get; set; }

        public void AddRecipient(string address)
        {
            Recipients.Add(new Recipient(this, address));
        }
    }
}