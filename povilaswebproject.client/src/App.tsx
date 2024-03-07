import { useEffect, useState } from "react";
import "./App.css";

// interface Forecast {
//     date: string;
//     temperatureC: number;
//     temperatureF: number;
//     summary: string;
// }
interface Forecast {
  id: number;
  name: string;
  price: number;
}

function App() {
  const [forecasts, setForecasts] = useState<Forecast[]>();

  useEffect(() => {
    populateWeatherData();
  }, []);

  const contents =
    forecasts === undefined ? (
      <p>
        <em>
          Loading... Please refresh once the ASP.NET backend has started. See{" "}
          <a href="https://aka.ms/jspsintegrationreact">
            https://aka.ms/jspsintegrationreact
          </a>{" "}
          for more details.
        </em>
      </p>
    ) : (
      <table className="table table-striped" aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Price</th>
            {/* <th>Date</th>
            <th>Temp. (C)</th>
            <th>Temp. (F)</th> */}
            {/* <th>Summary</th> */}
          </tr>
        </thead>
        <tbody>
          {forecasts.map((forecast) => (
            // <tr key={forecast.date}>
            <tr key={forecast.id}>
              {/* <td>{forecast.date}</td>
              <td>{forecast.temperatureC}</td>
              <td>{forecast.temperatureF}</td>
              <td>{forecast.summary}</td> */}
              <td>{forecast.id}</td>
              <td>{forecast.name}</td>
              <td>{forecast.price}</td>
              {/* <td>{forecast.summary}</td> */}
            </tr>
          ))}
        </tbody>
      </table>
    );

  return (
    <div>
      {/* <h1 id="tabelLabel">Weather forecast</h1> */}
      <h1 id="tabelLabel">Products</h1>
      <p>This component demonstrates fetching data from the server.</p>
      {contents}
    </div>
  );

  async function populateWeatherData() {
    // const response = await fetch("weatherforecast");
    const response = await fetch("products");
    const data = await response.json();
    setForecasts(data);

    console.log(data);
  }
}

export default App;
