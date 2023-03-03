import React, { useState } from 'react';
import '../MyFiles/table.css';

function PassengerForm(props) {
  const itinerary = JSON.parse(sessionStorage.getItem("itinerary"));
  const [name, setName] = useState('');
  const [birthdate, setBirthdate] = useState('');
  const [Px_Type, setPx_Type] = useState('singlePersonCost');
  const[Amount, setAmount] = useState();
  
// itinerary
  console.log("itinieririres : ",itinerary);

  const handleSubmit = (event) => {

    event.preventDefault();
    const passengerData = {
      name,
      birthdate,
      Px_Type,
      Amount
    };
    // console.log(passengerData);
   // setPassengerDataArray([...passengerDataArray, passengerData]);
    props.updatePass(passengerData);
    // console.log("passengerdata");
    // console.log(passengerData);
    setName('');
    setBirthdate('');
    setPx_Type('singlePersonCost');
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
        Name:
        <input type="text" value={name} onChange={(event) => setName(event.target.value)} />
      </label>
      <br/>
      <br/>
      <label>
        Birthdate:
        <input type="date" value={birthdate} onChange={(event) => setBirthdate(event.target.value)} />
      </label>
      <br/>
      <br/>
      <div>
        <label>Passenger Type</label>
        <br/><br/>
        <label>
          <input type="radio" name="Px_Type" value="singlePersonCost" checked={Px_Type === 'singlePersonCost'} onChange={() => {setPx_Type('singlePersonCost'); setAmount(itinerary[0].single_Person_Cost)}} />
          Single person cost : {itinerary[0].single_Person_Cost}
        </label>
      </div>
      <div>
        <label>
          <input type="radio" name="Px_Type" value="extraPersonCost" checked={Px_Type === 'extraPersonCost'} onChange={() =>{ setPx_Type('extraPersonCost'); setAmount(itinerary[0].extra_Person_Cost)}} />
          Extra person cost : {itinerary[0].extra_Person_Cost}
        </label>
      </div>
      <div>
        <label>
          <input type="radio" name="Px_Type" value="childWithBed" checked={Px_Type === 'childWithBed'} onChange={() => {setPx_Type('childWithBed'); setAmount(itinerary[0].child_with_Bed)}} />
          Child with bed  : {itinerary[0].child_with_Bed}
        </label>
      </div>
      <div>
        <label>
          <input type="radio" name="Px_Type" value="childWithoutBed" checked={Px_Type === 'childWithoutBed'} onChange={() => {setPx_Type('childWithoutBed'); setAmount(itinerary[0].child_without_Bed)}} />
          Child without bed : {itinerary[0].child_without_Bed}
        </label>
      </div>
      <button type="submit">Add Another Passenger</button>
     
      
    </form>
    </div>
  );
}

export default PassengerForm;













// import {  useState } from "react";
// import {  Table } from "react-bootstrap";

// import { useNavigate} from "react-router-dom";

// export default function PostCategaryMasters(){

//     const [categary, setCategary]=useState([]);
//     let navigate = useNavigate();


//     const handleChange = (event) =>{
//         const name = event.target.name;
//         const value = event.target.value;
//         setCategary(values => ({...values, [name]:value}))
//     }
  
//     const handleSubmit = (e) =>{
//         let data = JSON.stringify(categary);
//         fetch("http://localhost:5272/api/categary_master",{
//            method: 'POST',
//            headers: {'Content-type':'application/json'},
//            body: data 
//         }).then(res => res.json()) ;
//         e.preventDefault();
//         navigate('/');
//     }
    
//     return(
//         <div style={{    display: "flex",justifyContent:"center" }}>
//         <form onSubmit={handleSubmit}>
//             <Table striped bordered hover style={{width: "fit-content", backgroundColor: "#8ac0ef", margin: "10px" }}>
//             <thead>
//             <tr>
//             <th>catId</th>
//             <td><input type="text" name="catId" defaultValue={""} onChange={handleChange}/></td>
//             </tr>  
//             <tr>
//             <th>subcatId</th>
//             <td><input type="text" name="subcatId" defaultValue={""} onChange={handleChange}/></td>
//             </tr>  
//             <tr>
//             <th>catName</th>
//             <td><input type="text" name="catName" defaultValue={""} onChange={handleChange}/></td>
//             </tr>  
//             <tr>
//             <th>catImagePath</th>
//             <td><input type="text" name="catImagePath" defaultValue={""} onChange={handleChange}/></td>
//             </tr>  
//             <tr >
//             <td></td>
//             <td >
//             <input type="submit" style={{background: "blanchedalmond", borderRadius: "10px"}}/>
//             </td>
//             </tr>
//           </thead>
//         </Table>
         
//     </form>

//     </div>
//     )
// }
   
