﻿using PpeManager.Api.Application.DomainEventHandlers;
using PpeManager.Domain.AggregatesModel.AggregateCompany;
using PpeManager.Domain.AggregatesModel.AggregateWorker;
using PpeManager.Domain.Events;

namespace PpeManager.UnitTests.Domain.DomainHandler
{
    public class SetValidityToPpePossessionHandlerTest
    {
        private readonly Mock<IPpeRepository> _ppeRepositoryMock;
        private readonly Mock<IWorkerRepository> _workerRepositoryMock;
        private readonly Mock<NotificationContext> _notificationContextMock;

        public SetValidityToPpePossessionHandlerTest()
        {
            _ppeRepositoryMock = new Mock<IPpeRepository>();    
            _workerRepositoryMock = new Mock<IWorkerRepository>();
            _notificationContextMock = new Mock<NotificationContext>();
        }
        [Fact]
        public async Task Handler_set_validity_with_suceful()
        {
            //Arrange
            var notification = new SetValidityToPpePossession(0, 0);

            var ppe = new Ppe("Name", "Description");
            var ppeCertification = new PpeCertification(0, "55555", DateOnly.FromDateTime(DateTime.Now.AddDays(10)), 5);
            var listCertifications = new List<PpeCertification>();
            listCertifications.Add(ppeCertification);
            ppe.setPpeCertifications(listCertifications);

            var listPpe = new List<Ppe>();
            listPpe.Add(ppe);
            var ppePossession = new PpePossession(null, null, DateOnly.FromDateTime(DateTime.Now), 5);
            var listPossession = new List<PpePossession>(); 
            listPossession.Add(ppePossession);
            var worker = new Worker("Name", "Role", "092.444.670-62", "1234", DateOnly.FromDateTime(DateTime.Now).ToString(), new Company("Fake", "73.706.750/0001-57"), listPpe, listPossession);


            _ppeRepositoryMock.Setup(repo => repo.Find(It.IsAny<Func<Ppe, bool>>())).Returns(ppe);
            _workerRepositoryMock.Setup(repo => repo.Find(It.IsAny<Func<Worker, bool>>())).Returns(worker);

            //Act
            var handler = new SetValidityToPpePossessionHandler(_ppeRepositoryMock.Object, _workerRepositoryMock.Object, _notificationContextMock.Object);
            var cltToken = new System.Threading.CancellationToken();
            var result = handler.Handle(notification, cltToken);

            //Assert
            Assert.True(result.IsCompleted);
        }
    }
}