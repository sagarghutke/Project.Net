import React, { useState } from 'react';
import '../MyFiles/table.css';

function PassengerForm(props) {
  const itineraries = JSON.parse(sessionStorage.getItem("itineraries"));
  const [passengerName, setpax_Name] = useState('');
  const [birthdate, setpax_Birthdate] = useState('');
  const [passengerType, setpx_Type] = useState('singlePersonCost');
  const[passengerCost, setAmount] = useState();
  const [passengerId, setPax_id] = useState(0);
  const[bookingId, setBooking_Id] = useState(1);
  const[gender,setGender]=useState('');
  

  console.log("itinieririres : ",itineraries);

  const handleSubmit = (event) => {

    event.preventDefault();
    const passengerData = {
      passengerId,
      passengerName,
      birthdate,
      gender,
      passengerType,
      passengerCost,
      bookingId 
    };
    console.log(passengerData);
   // setPassengerDataArray([...passengerDataArray, passengerData]);
    props.updatePass(passengerData);
    // console.log("passengerdata");
    // console.log(passengerData);
    setpax_Name('');
    setpax_Birthdate('');
    setpx_Type('singlePersonCost');
  };

  return (
    <div  style={{
                background: "#ddd",
                color: "grey",
                display: "flex",
                flexDirection: "row",
                alignItems: "center",
                justifyContent: "center",
                backgroundColor: "white",
                padding: "1rem",
                borderRadius: "4px",
                boxShadow: "0 0 10px rgba(0, 0, 0, 0.5)",
                marginTop: "6vh",
            //    marginLeft: "auto",
             //   marginRight: "auto",
                marginBottom : "6vh"
              }}>
    <form onSubmit={handleSubmit}>
      <label>
        pax_Name:
        <input type="text" value={passengerName} onChange={(event) => setpax_Name(event.target.value)} />
      </label>
      <br/>
      <br/>
      <label>
        pax_Birthdate:
        <input type="date" value={birthdate} onChange={(event) => setpax_Birthdate(event.target.value)} />
      </label>
      <br/>
      <br/>
      <label>
        Gender:
        <input type="text" value={gender} onChange={(event) => setGender(event.target.value)} />
      </label>
      <br/>
      <br/>
      <div>
        <label>Passenger Type</label>
        <br/><br/>
        <label>
          <input type="radio" pax_Name="passengerType" value="singlePersonCost" checked={passengerType === 'singlePersonCost'} onChange={() => {setpx_Type('singlePersonCost'); setAmount(itineraries[0].singlePersonCost)}} />
          Single person cost : {itineraries[0].singlePersonCost}
        </label>
      </div>
      <div>
        <label>
          <input type="radio" pax_Name="passengerType" value="extraPersonCost" checked={passengerType === 'extraPersonCost'} onChange={() =>{ setpx_Type('extraPersonCost'); setAmount(itineraries[0].extraPersonCost)}} />
          Extra person cost : {itineraries[0].extraPersonCost}
        </label>
      </div>
      <div>
        <label>
          <input type="radio" pax_Name="passengerType" value="childWithBed" checked={passengerType === 'childWithBed'} onChange={() => {setpx_Type('childWithBed'); setAmount(itineraries[0].childWithBed)}} />
          Child with bed  : {itineraries[0].childWithBed}
        </label>
      </div>
      <div>
        <label>
          <input type="radio" pax_Name="passengerType" value="childWithoutBed" checked={passengerType === 'childWithoutBed'} onChange={() => {setpx_Type('childWithoutBed'); setAmount(itineraries[0].childWithoutBed)}} />
          Child without bed : {itineraries[0].childWithoutBed}
        </label>
      </div>
      <button type="submit">Add Another Passenger</button>  
     
      
    </form>
    </div>
  );
}

export default PassengerForm;