using _03_Clerk_Reference_System;

namespace _03_Clerk_Reference_System_Tests
{
    public class ClerkServiceTests
    {

        [Fact]
        public async void CertificateAcquisitionOrderTest()
        {
            var handler = new ClerkHandler();
            var service = new ClerkService();

            var clerk1 = new Clerk();
            var clerk2 = new Clerk();
            var clerk3 = new Clerk();
            var clerk4 = new Clerk();

            handler.AddIssueCertificate(clerk1, new Certificate(1));
            handler.AddRequirement(clerk1, new Certificate(2));

            handler.AddIssueCertificate(clerk2, new Certificate(2));
            handler.AddRequirement(clerk2, new Certificate(3));
            handler.AddRequirement(clerk2, new Certificate(4));

            handler.AddIssueCertificate(clerk3, new Certificate(3));

            handler.AddIssueCertificate(clerk4, new Certificate(4));

            var certificates = await service.CertificateAcquisitionOrderAsync([clerk1, clerk2, clerk3, clerk4]);

            Assert.True(certificates.SequenceEqual([3, 4, 2, 1]) || certificates.SequenceEqual([4, 3, 2, 1]));
        }
    }
}