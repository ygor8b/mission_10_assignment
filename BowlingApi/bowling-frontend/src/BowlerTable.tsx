// BowlerTable.tsx
// Fetches bowler data from the API and renders it in a table

import { useState, useEffect } from 'react';

// TypeScript interface defining the shape of each bowler object from the API
interface Bowler {
  bowlerFirstName: string;
  bowlerMiddleInit: string;
  bowlerLastName: string;
  teamName: string;
  bowlerAddress: string;
  bowlerCity: string;
  bowlerState: string;
  bowlerZip: string;
  bowlerPhoneNumber: string;
}

function BowlerTable() {
  // State to hold the array of bowlers fetched from the API
  const [bowlers, setBowlers] = useState<Bowler[]>([]);

  // Fetch bowler data once when the component mounts
  useEffect(() => {
    fetch('http://localhost:5256/api/bowlers')
      .then((res) => res.json())
      .then((data) => setBowlers(data))
      .catch((err) => console.error(err));
  }, []);

  return (
    <table className="bowler-table">
      <thead>
        <tr>
          <th>Name</th>
          <th>Team</th>
          <th>Address</th>
          <th>City</th>
          <th>State</th>
          <th>Zip</th>
          <th>Phone</th>
        </tr>
      </thead>
      <tbody>
        {/* Map over each bowler and render a table row */}
        {bowlers.map((b, i) => (
          <tr key={i}>
            <td>
              {b.bowlerFirstName} {b.bowlerMiddleInit} {b.bowlerLastName}
            </td>
            <td>{b.teamName}</td>
            <td>{b.bowlerAddress}</td>
            <td>{b.bowlerCity}</td>
            <td>{b.bowlerState}</td>
            <td>{b.bowlerZip}</td>
            <td>{b.bowlerPhoneNumber}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
}

export default BowlerTable;
