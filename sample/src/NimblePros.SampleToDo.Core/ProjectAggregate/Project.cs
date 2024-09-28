﻿using Ardalis.GuardClauses;
using NimblePros.SampleToDo.Core.ProjectAggregate.Events;
using Ardalis.SharedKernel;

namespace NimblePros.SampleToDo.Core.ProjectAggregate;

public class Project : EntityBase, IAggregateRoot
{
  public ProjectName Name { get; private set; }

  private readonly List<ToDoItem> _items = new();
  public IEnumerable<ToDoItem> Items => _items.AsReadOnly();
  public ProjectStatus Status => _items.All(i => i.IsDone) ? ProjectStatus.Complete : ProjectStatus.InProgress;

  // Note: Probably it makes more sense to prioritize items, not projects, but this is just an example
  public Priority Priority { get; }

  public Project(ProjectName name, Priority priority)
  {
    Priority = priority;
    Name = name;
  }

  public void AddItem(ToDoItem newItem)
  {
    Guard.Against.Null(newItem);
    _items.Add(newItem);

    var newItemAddedEvent = new NewItemAddedEvent(this, newItem);
    base.RegisterDomainEvent(newItemAddedEvent);
  }

  public void UpdateName(ProjectName newName)
  {
    Name = newName;
  }
}
