using System;
using ConsoleAppPictures.Model;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleAppPictures
{
    class Program
    {
        

        
            static async Task Main(string[] args)
            {
                


                var httpClient = new HttpClient();

                var httpResponse = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/users");
                var DenisUserId = 0;
                

                if (httpResponse.StatusCode==System.Net.HttpStatusCode.OK)
                {

                    var contentString = await httpResponse.Content.ReadAsStringAsync();

                    var users = JsonConvert.DeserializeObject<List<Users>>(contentString);


                     DenisUserId = users.Where(u => u.name == "Mrs. Dennis Schulist").Select(u => u.id).FirstOrDefault();
                    

                    System.Console.WriteLine($"Mrs. Dennis Shulist id: {DenisUserId}");


                }



                var albumsD = new List<int>();

                var httpClient1 = new HttpClient();

                    var httpResponse1 = await httpClient1.GetAsync("https://jsonplaceholder.typicode.com/albums");

                    if (httpResponse1.StatusCode == System.Net.HttpStatusCode.OK)
                    {

                        var contentString1 = await httpResponse1.Content.ReadAsStringAsync();

                        var albums = JsonConvert.DeserializeObject<List<Albums>>(contentString1);


                        var DenisAlbums = albums.Where(a => a.userId == DenisUserId).Select(a => a.id);

                            foreach (var a in DenisAlbums)
                            {
                                System.Console.WriteLine($"Mrs. Dennis Shulist album id: {a}");
                                albumsD.Add(a);


                            }
                    }



                var photosD = new List<int>();

                var httpClient2 = new HttpClient();

                    var httpResponse2 = await httpClient2.GetAsync("https://jsonplaceholder.typicode.com/photos");

                    if (httpResponse2.StatusCode == System.Net.HttpStatusCode.OK)
                    {

                        var contentString2 = await httpResponse2.Content.ReadAsStringAsync();

                        var photos = JsonConvert.DeserializeObject<List<Photos>>(contentString2);


                    foreach (var a in albumsD)
                    {
                        var DenisPhotos = photos.Where(p => p.albumId == a).Select(p => p.id);
                    

                        foreach (var p in DenisPhotos)
                        {
                            System.Console.WriteLine($"Mrs. Dennis Shulist photos id: {p}");
                            photosD.Add(p);

                        }
                    }
                    }


        }
        }
    }

