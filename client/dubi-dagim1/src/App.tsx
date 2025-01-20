import React from 'react';
import logo from './logo.svg';
import './App.css';
import SingUp from './Components/SingUp/SingUp';
import { Route, Routes } from 'react-router-dom';
import Home from './Components/Home/Home';
import NotFound from './Components/NotFound/NotFound';
import Header from './Components/Header/Header';

function App() {
  return (
    <div className="App">
    
        
      
      <Routes>
        
        <Route path="/" element={<Header></Header>}>
          {/* <Route index element={<Home></Home>}></Route> */}
          <Route path="Home" element={<Home></Home>} ></Route>
          <Route path="SingUp" element={<SingUp></SingUp>}></Route>
        </Route>
        <Route path="Home" element={<Home></Home>}></Route>
        <Route path="*" element={<NotFound></NotFound>}></Route>
      </Routes>
      
      
    </div>
  );
}

export default App;
