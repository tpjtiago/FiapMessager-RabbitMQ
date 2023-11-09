﻿using Core;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Produtor.Controllers
{
    [ApiController]
    [Route("/Pedido")]
    public class PedidoController : Controller
    {
        [HttpPost]
        public IActionResult Post() 
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            using (var connection = factory.CreateConnection())
            {
                using(var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: "fila",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    var message = JsonSerializer.Serialize(
                        new Pedido(1,
                            new Usuario(2, "Tiago", "tiago@email.com.br")));

                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(
                        exchange: "",
                        routingKey: "fila",
                        body: body);
                }
                return Ok();
            }
        }

    }
}
