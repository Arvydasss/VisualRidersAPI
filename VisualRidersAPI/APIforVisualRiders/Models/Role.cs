
﻿namespace apiForVisualRiders.Models
{
    public class Role
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public Guid PermissionId { get; set; }
    }
}

