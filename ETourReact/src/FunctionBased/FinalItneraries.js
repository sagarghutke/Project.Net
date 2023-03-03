import React, { useState, useEffect } from 'react';
import { Button } from 'react-bootstrap';
import { useNavigate, useParams } from "react-router-dom";


function Itineraries(props) {
  const [itineraries, setItineraries] = useState([]);

  const{code} =useParams();
  
  const [isLoggedIn, setIsLoggedIn] = useState(sessionStorage.getItem("isLoggedIn"));

  let navigate = useNavigate();


    const checkforlogin = () => {

      
      if (sessionStorage.getItem('isLoggedIn')) {
       
        // console.log("Dondndnvn");
        navigate("/BookingPage");
      }
      else{
        //console.log("bfnbndln");  
         alert("You have not logged in Please Login");
      }


    };


  useEffect(() => {
    console.log(code)
    
    fetch("https://localhost:7200/api/Itnerary_Master/"+code)
      .then(response => response.json())
      .then(data => {
        if(data)
        {
          setItineraries(data);
          sessionStorage.setItem('itineraries',JSON.stringify(data));
        }
      }
       ).catch(error => console.log(error));
  }, []);

  return (<div class="container mt-3">
          
  <div class="row" style={{    backgroundColor : "#92badc"}}>
    
    <div class="col ">
    {itineraries.map(item => (
          <li key={item.itinerary.itneraryId}>
            <div class="card" >
           <img src={item.categoryImage} class="card-img-top" alt="..." style={{height:"20rem"}}/>
          </div>
            <h2>tour_Duration: {item.itinerary.tourDuration}</h2>
            <p>Category: {item.itinerary.masterId}</p>
            <p>Single Person Cost: {item.singlePersonCost}</p>
            <p>Extra Person Cost: {item.extraPersonCost}</p>
            <p>Child with Bed: {item.childWithBed}</p>
            <p>Child without Bed: {item.childWithoutBed}</p>
            <p>Valid From: {item.validFrom}</p>
            <p>Valid To: {item.validTo}</p>
            <Button onClick={checkforlogin}>Book</Button>
          </li>
        ))}
    </div>
    <div class="col ">
    {itineraries.map(item => (
          <li key={item.itinerary.itneraryId}>
            <h2>{item.categoryName}</h2>
            <div>
            {item.itinerary.itnerarydetails.split("...").map((line, index) => (
              <p align="left" key={index}>{line}</p>
            ))}
          </div>
          </li>
        ))}
    </div>
  </div>
</div>
  );
}

export default Itineraries;