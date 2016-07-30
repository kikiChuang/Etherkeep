﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspNet.Security.OAuth.Validation;
using System;
using Etherkeep.Server.ViewModels.Extensions;
using OpenIddict;
using Microsoft.EntityFrameworkCore;
using Etherkeep.Server.ViewModels.Account;
using Etherkeep.Data.Entities;
using Etherkeep.Shared.Services.Email;
using Etherkeep.Shared.Services.Sms;
using Etherkeep.Data;
using Etherkeep.Data.Repository;

namespace Etherkeep.Server.Controllers
{
    [Authorize(ActiveAuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
    //[Route("api/[controller]")]
    [Route("api/accounts")]
    public class AccountsController : BaseController
    {
        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;

        public AccountsController(
            ApplicationDbContext applicationDbContext,
            OpenIddictUserManager<User> userManager,
            IEmailSender emailSender,
            ISmsSender smsSender,
            ILoggerFactory loggerFactory) : base(applicationDbContext, userManager, loggerFactory)
        {
            _emailSender = emailSender;
            _smsSender = smsSender;
            _logger = loggerFactory.CreateLogger<AccountsController>();
        }

        [HttpGet, Route("activities")]
        public async Task<IActionResult> ActivitiesAction(int? page)
        {
            try
            {
                int pageNumber = page ?? 1;

                int pageSize = 10;

                var user = await GetCurrentUserAsync();

                var activities = _applicationDbContext.Activities
                    .Include(e => e.Parameters)
                    .Where(e => e.UserId == user.Id);

                var result = new PagedResult<ActivityViewModel>
                {
                    TotalCount = activities.Count(),
                    Items = activities.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToViewModel()
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);

                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return BadRequest(ModelState);
        }
    }
}