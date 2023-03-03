import React from 'react';
import { BrowserRouter, Routes, Route, Outlet } from "react-router-dom";
import DisplayCategary from './DisplayCategary';
import UpdateCategary from './UpdateCategary';
import DeleteCategary from './DeleteCategary';
import CategaryMasters from './CategaryMasters';
import PostCategaryMasters from './PostCategaryMasters';
import FormPage from './FormPage';
import Search from './FinalSearch';
import HomePage from './FinalHomePageFunctional';
import Itineraries from './FinalItneraries'
//import NavigationBar from './Navbar';
import Home from './FinalHomeLayout';
import Register from './Register';
import LoginModal from './LoginModal';
import LoginForm from './LoginForm';
import { NavigationBar } from './FinalNavBar';
import ContentSearch from './ContentSearch';
import ContentSearchTrial from './ContentSearchTrial';
import BookingPage from './BookingPage';
import PassengerForm from './PassengerForm';



function Routetable() {
  return (
    <div>
       
    <BrowserRouter>
    <Routes>
      <Route path="/" element={<Home/>}>
         <Route index element={<HomePage/>}/>
         {/* <Route path="displayCategary/:code" element={<DisplayCategary/>}/>
        <Route path="updateCategary/:code" element={<UpdateCategary/>}/>
        <Route path="deleteCategary/:code" element={<DeleteCategary/>}/>
        <Route path="deleteCategary/:code" element={<DeleteCategary/>}/>
        <Route path="categaryMasters" element={<CategaryMasters/>}/> */}
        <Route path="Search" element={<Search/>}/>
        <Route path="Search/:code" element={<Search/>}/>
        <Route path="HomePage" element={<HomePage/>}/>
        {/* <Route path="PostCategaryMasters" element={<PostCategaryMasters/>}/> */}
        {/* <Route path="FormPage" element={<FormPage/>}/>  */}
        {/* <Route path="Itineraries/:code" element={<Itineraries/>}/>  */}
        <Route path="Itineraries/:code" element={<Itineraries/>}/>
        <Route path="RegistrationForm" element={<Register/>}/>
        <Route path="LoginModal" element={<LoginModal/>}/>
        <Route path="LoginForm" element={<LoginForm/>}/>
        <Route path="ContentSearch" element={<ContentSearch/>}/>
        <Route path="ContentSearchTrial" element={<ContentSearchTrial/>}/>
        <Route path="Itineraries" element={<Itineraries/>}/>
        <Route path="Book" element={<BookingPage/>}/>
        <Route path="PassengerForm" element={<PassengerForm/>}/>
        <Route path="BookingPage" element={<BookingPage/>}/>
      </Route>
    </Routes>
    </BrowserRouter> 
    
    </div>
  )
}
export default Routetable;
