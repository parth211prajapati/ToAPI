﻿namespace ToAPI.Helper
{
    public class APIResponse
    {
        public int ResponseCode { get; set; }

        public string? Result { get; set; }

        public string? Errormessage { get; set; }
        public string Message { get; internal set; }
    }
}
