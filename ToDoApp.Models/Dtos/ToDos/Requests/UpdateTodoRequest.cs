﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models.Entities;

namespace ToDoApp.Models.Dtos.ToDos.Requests;

public sealed record UpdateToDoRequest(Guid Id,string Title, string Description, DateTime StartDate, DateTime EndDate,Priority Priority, int CategoryId, bool Completed);
