# Infotrack

## Installation

Please install docker via https://www.docker.com/

## Usage

Go to the root folder<br />
Open the command line<br />
<code>run "cd ./InfoTrace.Back-End"</code><br />
<code>run "docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d --build"</code><br />
<code>run "cd ../InfoTrace.Front-End"</code><br />
<code>run "docker-compose -f docker-compose.yml up -d --build"</code><br />

<hr/>
Windows can run the start.cmd in the root floder<br />

## Back-End Architecture

Back-End architectrue designed as a Microservice based on Asp.Net Core<br/>
<b>Teck Stack</b>

<ul>
<li>Apigateway(Ocelot)</li>
<li>.Net 5</li>
<li>MediatR</li>
<li>FluentValidation</li>
<li>Caching</li>
<li>Strategy Design Pattern</li>
<li>Error Hanlding</li>
</ul>
<b>ApiGateway</b> will hanlder all the client request and assign to related services<br/>
<b>InfoTrace.Microservice</b> is the service which provide google scraping api and bing scraping api.<br/>

### InfoTrack.Microservice

Infotrace.Microservice incluede 2 project as following

<ul>
<li>InfoTrace.API</li>
<li>InfoTrace.Infrastructure</li>
</ul>
<b>InfoTrace.API</b> is the entry point of the service. this service handle the http request, validate the request data, and caching the data every 300s.<br/>
Function as following<br>
<ul>
<li>Each request has validation for the request json data</li>
<li>In order to hanlding large data set, the API has the caching feature. the request with same body will caching the response for 300s.</li>
<li>Error Hanlding. The error will write into the log file with the traceid that can trace back the error message via traceid</li>
<li>Logging. Each Api started and ended will write log</li>
</ul>
<b>InfoTrace.Infrastructure</b> is the class library. provide the class to scraping the website. the scraping architecture designed as a Strategy Design Pattern. Depence on different search engine will execute different method scrape the content.<br/>
the swagger addres: https://localhost:7002/swagger/index.html<br/>

### ApiGateway

Apigateway is the entrypoint of the service. It will redirect the request to different service internally.<br/>
for example:<br/>
http://localhost:7000/trace/bing -> http://localhost:7002//v1/api/Trace/bing

request from http://localhost:7000/trace/bing will be reallocate to http://localhost:7002//v1/api/Trace/bing with the request data. Can review the configuration file in Infotrace/InfoTrace.Back-End/src/ApiGateway/APIGateway/ocelot.json both ApiGateway and InfoTrace.Microservice host on Docker. It is not just a simply "request redirection" via http.

### Test

Test Project location: Infotrace/InfoTrace.Back-End/InfoTrace.Tests/<br/>

<ul>
<li>BingScrapingTester tests the bing scraping strategy scrape bing page 1 to 10</li>
<li>GoogleScrapingTester.cs tests the google scraping strategy scrape google page 1 to 10</li>
<li>InfoTraceAPITester.cs tests the API return the correct data</li>
</ul>

## Front-End Architecture

the Front-End base on React. It is a simply form application.

<b>Teck Stack</b>

<ul>
<li>React</li>
<li>Redux</li>
<li>Bootsrap</li>
<li>axios</li>
<li>formik</li>
<li>yup</li>
<li>typescript</li>
</ul>

Location: http://localhost:3001/
