import { useState, useEffect, useCallback } from "react";
import "./App.css";

function App() {
  const [rates, setRates] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  const API_BASE = process.env.REACT_APP_API_BASE;
  const API_NBP_TABLE = process.env.REACT_APP_API_NBP_TABLE;
  
  const fetchRates = useCallback(async () => {
  if (!API_BASE || !API_BASE.includes(":")) {
    setError("Please complete the information correctly in .env (REACT_APP_API_BASE)");
    setLoading(false);
    return;
  }

  try {
    setLoading(true);
    setError(null);

    const res = await fetch(`${API_BASE}${API_NBP_TABLE}`, {
      method: "GET",
    });

    if (!res.ok) throw new Error("Error fetching data...");
    const data = await res.json();
    setRates(data);
  } catch (err) {
    setError(err.message);
  } finally {
    setLoading(false);
  }
}, [API_BASE, API_NBP_TABLE]);


  useEffect(() => {
    fetchRates();
  }, [fetchRates]);

  if (loading) return <p>Loading data...</p>;
  if (error) return <p>Error: {error}</p>;

  return (
    <div className="container">
      <h1 className="title">Exchange rates from the NBP</h1>
      <button className="button" onClick={fetchRates}>
        Refresh
      </button>
      <table className="table">
        <thead>
          <tr>
            <th className="th">Currency</th>
            <th className="th">Code</th>
            <th className="th">Average exchange rate</th>
          </tr>
        </thead>
        <tbody>
          {rates.map((r, idx) => (
            <tr className="tr" key={idx}>
              <td className="td">{r.currency}</td>
              <td className="td">{r.code}</td>
              <td className="td">{r.mid}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default App;