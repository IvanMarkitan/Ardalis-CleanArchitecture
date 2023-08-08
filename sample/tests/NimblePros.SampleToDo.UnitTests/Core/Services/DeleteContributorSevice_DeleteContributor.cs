﻿using NimblePros.SampleToDo.Core.ContributorAggregate;
using NimblePros.SampleToDo.Core.Services;
using Ardalis.SharedKernel;
using MediatR;
using Moq;
using Xunit;
using Microsoft.Extensions.Logging;

namespace NimblePros.SampleToDo.UnitTests.Core.Services;

public class DeleteContributorService_DeleteContributor
{
  private readonly Mock<IRepository<Contributor>> _mockRepo = new Mock<IRepository<Contributor>>();
  private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
  private readonly Mock<ILogger<DeleteContributorService>> _mockLogger = new Mock<ILogger<DeleteContributorService>>();
  private readonly DeleteContributorService _service;

  public DeleteContributorService_DeleteContributor()
  {
    _service = new DeleteContributorService(_mockRepo.Object, _mockMediator.Object, _mockLogger.Object);
  }

  [Fact]
  public async Task ReturnsNotFoundGivenCantFindContributor()
  {
    var result = await _service.DeleteContributor(0);

    Assert.Equal(Ardalis.Result.ResultStatus.NotFound, result.Status);
  }
}