import { useState, useEffect } from "react";

function App() {
  const [rates, setRates] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  const fetchRates = async () => {
    try {
      setLoading(true);
      const res = await fetch("https://localhost:44384/api/NBPTable/getFromDatabase", {
        method: "GET"
      });
      console.log(res);
      if (!res.ok) throw new Error("Error fetching data...");
      const data = await res.json();
      setRates(data);
    } catch (err) {
      setError(err.message);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchRates();
  }, []);

  if (loading) return <p>Loading data...</p>;
  if (error) return <p>Error: {error}</p>;

  return (
    <div style={{ padding: 10 }}>
      <h1>Exchange rates from the NBP</h1>
      <button onClick={fetchRates} style={{ marginBottom: 10 }}>
        Refresh
      </button>
      <table border="1" cellPadding="10">
        <thead>
          <tr>
            <th>Currency</th>
            <th>Code</th>
            <th>Average exchange rate</th>
          </tr>
        </thead>
        <tbody>
          {rates.map((r, idx) => (
            <tr key={idx}>
              <td>{r.currency}</td>
              <td>{r.code}</td>
              <td>{r.mid}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default App;