﻿using DraftLabOne.API.Contracts;
using DraftLabOne.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace DraftLabOne.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApplicationController : ControllerBase
    {
        protected new ActionResult Ok(object? result = null)
        {
            var envelope = Envelope.Ok(result);
            return base.Ok(envelope);
        }

        protected  IActionResult BadRequest(Error? error)
        {
            var errorInfo = new ErrorInfo(error);
            var envelope = Envelope.Error(errorInfo);
            return base.BadRequest(envelope);
        }

        protected IActionResult NotFound(Error? error)
        {
            var errorInfo = new ErrorInfo(error);
            var envelope = Envelope.Error(errorInfo);
            return base.NotFound(envelope);
        }
    }
}
