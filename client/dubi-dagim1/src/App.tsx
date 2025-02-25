import React from 'react';
import logo from './logo.svg';
import './assets/css/app.css';
import { BrowserRouter as Router,Route, Routes } from 'react-router-dom';
import { UserProvider } from './context/UserContext';
import Home from './Components/Home/Home';
import NotFound from './Components/NotFound/NotFound';
import Layout from './Components/Layout';
import SignUp from './Components/SignUp/SignUp';
import Login from './Components/Login';
import Categories from './Components/Categories';
import InnerCategory from './Components/InnerCategory';

import Editing from './Components/Editing';

function App() {
  return (
    <div className="App">
      <UserProvider>
        
        <Routes>
          {/* מסגרת לכל הדפים */}
          <Route path="/" element={<Layout />}>
            <Route index element={<Home />} />
            <Route path="signup" element={<SignUp />} />
            <Route path="/login" element={<Login />} />
            <Route path="*" element={<NotFound />} />
            <Route path='categories' element={<Categories/>}/>
            <Route path="category/:id" element={<InnerCategory/>}/>
            <Route path="editing" element={<Editing/>}/>

          </Route>

          {/* עמודים מחוץ למסגרת */}
          
        </Routes>
        
      </UserProvider>
    </div>
  );
}

export default App;
