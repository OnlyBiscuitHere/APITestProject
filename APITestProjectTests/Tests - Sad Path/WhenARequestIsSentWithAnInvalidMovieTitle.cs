﻿using NUnit.Framework;
using System.Linq;
using APITestProjectTests.MovieIOService;
using System.Threading.Tasks;

namespace APITestProjectTests.Tests___Sad_Path
{
    public class WhenARequestIsSentWithAnInvalidMovieTitle
    {
        private MovieServices _movieServices;
        [OneTimeSetUp]
        public async Task OneTimeSetup()
        {
            _movieServices = new MovieServices();
            await _movieServices.MakeAMovieRequestAsync("idk");
        }
        [Test]
        public void GivenAnInvalidMovieTitle_ResponseIsFalse()
        {
            Assert.That(_movieServices.MovieResponseDTO.Response, Is.EqualTo("False"));
        }
    }
}