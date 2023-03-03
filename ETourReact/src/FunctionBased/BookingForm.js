import { useEffect, useState } from "react";
import {
  Radio,
  RadioGroup,
  FormGroup,
  FormControl,
  Input,
  InputLabel,
  FormLabel,
  Typography,
  styled,
  Select,
  MenuItem,
  Button,
  Checkbox,
  FormControlLabel,
} from "@mui/material";
import PassengerForm from "./PassengerForm";
 import { Modal } from "@mui/material";
// import TableOnPage from "./TableOnPage";
const Container = styled(FormGroup)`
  width: 50%;
  margin: 5% auto 0 auto;
  & > div {
    margin-top: 20px;
  }
`;
export default function BookingPage() {
  const customer = JSON.parse(sessionStorage.getItem("customer"));
  console.log(customer.customerId);
  const [isOpen, setIsOpen] = useState(false);
  const [passenger, setPassenger] = useState();
  const handleOpen = () => setIsOpen(true);
  const handleClose = () => setIsOpen(false);
  const itineraries = JSON.parse(sessionStorage.getItem("itineraries"));
  const extraPersonCost = sessionStorage.getItem("extraPersonCost");
  const childWithBed = sessionStorage.getItem("childWithBed");
  const childWithoutBed = sessionStorage.getItem("childWithoutBed");

  //  let arrayCost1 += parseInt(sessionStorage.getItem("arrayCost"));
  // arrayCost1 += parseInt(sessionStorage.getItem("arrayCost"));

//  console.log(itineraries[0].singlePersonCost)
//   console.log(itineraries[0].extraPersonCost);
//   console.log(itineraries[0].childWithBed);
//   console.log(itineraries[0].childWithoutBed);
//   console.log(itineraries);

  useEffect(() => {
    fetch("https://localhost:7200/api/Passenger_Master/" + customer.customerId)
      .then((res) => res.json())
      .then((result) => {
        setPassenger(result);
        console.log("vsdvjsv");
        console.log(passenger);

        const table = document.getElementById("results-table");
        table.innerHTML = "";
        const headers = [
          "Passenger Id",
          "Name",
          "BirthDate",
          "Gender",
          "Passenger Cost",
          "Passenger Type",
          "DepartureDate",
        ];
        const headerRow = document.createElement("tr");
        headers.forEach((header) => {
          const th = document.createElement("th");
          th.textContent = header;
          headerRow.appendChild(th);
        });
        table?.appendChild(headerRow);

        // Create table rows
        passenger?.forEach((result) => {
          const row = document.createElement("tr");
          Object.values(result).forEach((value) => {
            const cell = document.createElement("td");
            cell.textContent = value;
            row.appendChild(cell);
          });
          table?.appendChild(row);
        });
      });
  }, []);

  return (
    <Container>
      <Typography variant="h4">Book Tour</Typography>
      <FormControl>
        <InputLabel>Name</InputLabel>
        <Input name="Cust_Name" defaultValue={customer.customerName} />
      </FormControl>
      <FormControl>
        <InputLabel>Email</InputLabel>
        <Input name="Email" defaultValue={customer.email} />
      </FormControl>
      {/* <FormControl>
        <InputLabel>Password</InputLabel>
        <Input name="Password" defaultValue={customer.password} />
      </FormControl> */}
      <FormControl>
        <InputLabel>Country_Code</InputLabel>
        <Input name="Country_Code" defaultValue={customer.countryCode} />
      </FormControl>
      <FormControl>
        <InputLabel>Phone_Number</InputLabel>
        <Input name="Phone_Number" defaultValue={customer.phoneNumber} />
      </FormControl>
      <FormControl>
        <InputLabel>Address</InputLabel>
        <Input name="Address" defaultValue={customer.address} />
      </FormControl>
      <FormControl>
        <InputLabel>Proof_Id</InputLabel>
        <Input name="Proof_Id" defaultValue={customer.idVerificationType} />
      </FormControl>
      <FormControl>
        <InputLabel>Gender</InputLabel>
        <Input name="Gender" defaultValue={customer.gender} />
      </FormControl>
      <FormControl>
        <InputLabel>Age</InputLabel>
        <Input name="Age" defaultValue={customer.age} />
      </FormControl>
      <Button variant="contained" href='/PassengerForm'>
        Add Passenger
      </Button>
      {/* <Passenger isOpen={isOpen} onClose={handleClose} /> */}
      <FormControl>
        <Button variant="contained">Done</Button>
      </FormControl>
      <br />
      <br />
      <table
        class="container-xxl col-md-6 mb-2 bordered-table "
        id="results-table"
      ></table>
    </Container>
  );
}

// const Passenger = ({ isOpen, onClose }) => {
//   const itineraries = JSON.parse(sessionStorage.getItem("itineraries"));
//   //const defaultValue = new Date();
//   const customer = JSON.parse(sessionStorage.getItem("customer"));
//   const [passengerName, setPaxName] = useState("");
//   const [birthdate, setPaxBirthdate] = useState("");
//   const [gender, setGender] = useState("");
//   const [passengerType, setPaxType] = useState("adult");
//   const [arrayCost, setarrayCost] = useState();
//   const customerId = customer.customerId;
//   //console.log(itineraries[0].departureDate)
//   const departureDate = new Date(itineraries[0].departureDate);
  
 

//   function addCost(selectedValue) {
//     if (selectedValue === "SPC") {
//       sessionStorage.setItem(
//         "Single_Person_Cost",
//         itineraries[0].singlePersonCost
//       );
//       setarrayCost(itineraries[0].singlePersonCost);
//       console.log("SPC DONE");
//       console.log(arrayCost);
//     } else if (selectedValue === "EPC") {
//       sessionStorage.setItem(
//         "ExtraPersonCost",
//         itineraries[0].extraPersonCost
//       );
//       setarrayCost(itineraries[0].extraPersonCost);
//       console.log("EPC done");
//       console.log(arrayCost);
//     } else if (selectedValue === "CWB") {
//       sessionStorage.setItem("Child_With_Bed", itineraries[0].childWithBed);
//       setarrayCost(itineraries[0].childWithBed);
//       console.log("with", arrayCost);
//       console.log("CWB DONE");
//     } else if (selectedValue === "CWTB") {
//       sessionStorage.setItem(
//         "Child_Without_Bed",
//         itineraries[0].childWithoutBed
//       );
//       setarrayCost(itineraries[0].childWithoutBed);
//       console.log("vsdkvbsd", arrayCost);
//       console.log("CWTB DONE");
//     }
//   }

//   const handleSubmit = () => {
//     // Construct the passenger object with the form data

//     sessionStorage.setItem("arrayCost", arrayCost);
//     // //console.log(sessionStorage.getItem("arraycost")); 
//     // const cost =  sessionStorage.getItem("arrayCost");
//     // console.log(parseInt(cost));
//     // //console.log(cost);
//     const values = {
//       passengerName: passengerName,
//       birthdate: birthdate,
//       gender:gender,
//       passengerCost: parseInt(sessionStorage.getItem("arrayCost")),
//       customerId: customerId,
//       departureDate: departureDate,
//       passengerType:passengerType
//     };
//     console.log(values);
//     // Send a POST request to the server with the passenger information
//     fetch("https://localhost:7200/Passenger_Master", {
//       method: "POST",
//       headers: { "Content-Type": "application/json" },
//       body: JSON.stringify(values),
//     })
//       .then((response) => {
//         console.log("Data added");
//       })
//       .catch((error) => {
//         // Handle errors
//         console.error(error);
//         onClose(); // close the modal after submission
//       });
//   };


//   // const handleAdd=()=>{
//   //   fetch()
//   // }

//   return (
//     <Modal open={isOpen} onClose={onClose}>
//       <div
//         style={{
//           background: "black",
//           color: "grey",
//           display: "flex",
//           flexDirection: "row",
//           alignItems: "center",
//           justifyContent: "center",
//           backgroundColor: "white",
//           padding: "1rem",
//           borderRadius: "4px",
//           boxShadow: "0 0 10px rgba(0, 0, 0, 0.5)",
//           marginTop: "6vh",
//           marginLeft: "auto",
//           marginRight: "auto",
//         }}
//       >
//         <div>
//           <Typography variant="h4">Add Passenger</Typography>
//           <br/>
//           <FormControl style={{ marginBottom: "1rem" }}>
//             <InputLabel>PassengerName</InputLabel>
//             <Input
//               type="text"
//               name="passengerName"
//               value={passengerName}
//               onChange={(e) => setPaxName(e.target.value)}
//             />
//           </FormControl>
//           <br />
//           <FormControl style={{ marginBottom: "3rem" }}>
//             <InputLabel style={{ marginBottom: "3rem" }}>
//               Birthdate
//             </InputLabel>
//             <br />
//             <br />
//             <br/>
//             <Input
//               type="date"
//               name="birthdate"
//               value={birthdate}
//               onChange={(e) => setPaxBirthdate(e.target.value)}
//             />
//           </FormControl>
//           <br/>
//           <br/>
//           <FormControl style={{ marginBottom: "1rem" }}>
//             <InputLabel>Gender</InputLabel>
//             <Input
             
//               name="gender"
//               value={gender}
//               onChange={(e) => setGender(e.target.value)}
//             />
//           </FormControl>
//           <InputLabel>PassengerType</InputLabel>
//           <br />
//           <br />
//           <FormControl>
//             <RadioGroup
//               name="passengerType"
//               value={passengerType}
//               onChange={(e) => {
//                 setPaxType(e.target.value);
//                 addCost(e.target.value);
//               }}
//             >
//               <FormControlLabel
//                 value="SPC"
//                 control={<Radio />}
//                 label={
//                   "Single Person Cost: " + itineraries[0].singlePersonCost
//                 }
//               />
//               <FormControlLabel
//                 value="EPC"
//                 control={<Radio />}
//                 label={
//                   "Extra Person Cost : " + itineraries[0].extraPersonCost
//                 }
//               />
//               <FormControlLabel
//                 value="CWB"
//                 control={<Radio />}
//                 label={"Child With Bed : " + itineraries[0].childWithBed}
//               />
//               <FormControlLabel
//                 value="CWTB"
//                 control={<Radio />}
//                 label={
//                   "Child Without Bed : " + itineraries[0].childWithoutBed
//                 }
//               />
//             </RadioGroup>
//           </FormControl>
//         </div>
//         <br />

//         <div style={{ marginTop: "60vh" }}>
//           <FormControl>
//             <Button variant="contained" onClick={handleSubmit}>Add New Passenger</Button>
//           </FormControl>
//           <br />
//           <br />
//           <FormControl>
//             <Button variant="contained" >
//               Submit
//             </Button>
//           </FormControl>
//         </div>
//       </div>
//     </Modal>
 // );
//};