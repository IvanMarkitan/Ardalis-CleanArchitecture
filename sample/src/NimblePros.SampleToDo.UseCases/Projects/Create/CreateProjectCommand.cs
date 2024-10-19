﻿using Ardalis.Result;
using NimblePros.SampleToDo.Core.ProjectAggregate;

namespace NimblePros.SampleToDo.UseCases.Projects.Create;

/// <summary>
/// Create a new Project.
/// </summary>
/// <param name="Name"></param>
public record CreateProjectCommand(string Name) : Ardalis.SharedKernel.ICommand<Result<ProjectId>>;
