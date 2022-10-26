# Clima
Consumo de uma Api externa de Clima

🏗 O que fazer? - Disponibilizar um endpoint que retorna informações de temperatura (min, max, atual) de uma determinada cidade a ser definida por parâmetro.
Os dados devem climáticos (min, max, atual) devem ser coletados na API do OpenWeather (https://openweathermap.org/api);
A cada requisição, os dados climáticos devem ser armazenadas a fim de serem usadas como cache.
Ao solicitar os dados para uma cidade, deve-ser verificar se existe dados climáticos dos últimos 20 minutos no banco de dados. Se houver, retonar esses dados via API. Somente então se não houver dados para serem usados como cache, consultar os do openweathermap. O objetivo é evitar chamadas desnecessárias ao openweathermap e retornar um resultado mais rápido.

🚨Requisitos:
O código deve usar .NET CORE C#;
Implementar operações no banco de dados utilizando um ORM ou Micro ORM ORM's/Micro ORM's permitidos: Entity Framework Core;
Utilizar Conceitos SOLID;
Boas práticas da Linguagem/Framework;

