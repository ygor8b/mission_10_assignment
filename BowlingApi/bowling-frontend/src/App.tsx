// App.tsx
// Root component that composes the Heading and BowlerTable components

import Heading from './Heading';
import BowlerTable from './BowlerTable';

function App() {
  return (
    <div className="app-container">
      <Heading />
      <BowlerTable />
    </div>
  );
}

export default App;
