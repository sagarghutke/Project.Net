import { useEffect, useState } from "react";
import '../MyFiles/table.css';
import {
    FormGroup,
  FormControl,
  Input,
  InputLabel,
    Typography,
  styled,
    Button,
  } from "@mui/material";
import PassengerForm from "./PassengerForm";
const Container = styled(FormGroup)`
  width: 50%;
  margin: 5% auto 0 auto;
  & > div {
    margin-top: 20px;
  }
`;
// export default function BookingPage() {
//   const customer = JSON.parse(sessionStorage.getItem("customer"));
//    console.log(customer.customer.customerId);


 
//   const itineraries = JSON.parse(sessionStorage.getItem("itineraries"));
//     console.log("fucj",itineraries[0]);
//   const [arrayOfPass, setArrayOfPass] = useState([]);

//   function getCurrentDate() {
//     const currentDate = new Date();
//     const year = currentDate.getFullYear();
//     const month = String(currentDate.getMonth() + 1).padStart(2, '0');
//     const day = String(currentDate.getDate()).padStart(2, '0');
//     return `${year}-${month}-${day}`;
//   }
  

//   const getUpdatedPass = (arr) => {
//     setArrayOfPass(prevArray => [...prevArray, arr]);
//   }

// //   console.log("master id",itineraries[0].itinerary.masterId);
// //   console.log("Array of Pass of Booking page" , arrayOfPass);

//   const onPost = () => {

//  const BookingData = {
//   bookingDate: getCurrentDate(),
//   noOfPassenger: arrayOfPass.length,
//   tourAmount: 0,
//   taxes: 0,
//   totalAmount: 0,
//   masterId: itineraries[0].itinerary.masterId,
//   customerId: customer.customerId,
//   departureId: itineraries[0].date.departureDate,
//   passenger: arrayOfPass,
// };
//     console.log("BookingData");
//     console.log(BookingData);

    
//  fetch("https://localhost:7200/api/Search", {
//   method: "POST",
//   headers: { "Content-type": "application/json" },
//   body: JSON.stringify(BookingData),
// })
//   .then((res) => res.json())
//   .then(console.log("Done na bosssssssss"));
  
//   }

//   return (
//     <Container>
//       <Typography variant="h4">Book Tour</Typography>
//       <FormControl>
//         <InputLabel>Name</InputLabel>
//         <Input name="customerName" defaultValue={customer.customer.customerName} />
//       </FormControl>
//       <FormControl>
//         <InputLabel>Email</InputLabel>
//         <Input name="email" defaultValue={customer.customer.email} />
//       </FormControl>
//       {/* <FormControl>
//         <InputLabel>Password</InputLabel>
//         <Input name="password" defaultValue={customer.customer.password} />
//       </FormControl> */}
//       <FormControl>
//         <InputLabel>Country_Code</InputLabel>
//         <Input name="countryCode" defaultValue={customer.customer.countryCode} />
//       </FormControl>
//       <FormControl>
//         <InputLabel>Phone_Number</InputLabel>
//         <Input name="phoneNumber" defaultValue={customer.customer.phoneNumber} />
//       </FormControl>
//       <FormControl>
//         <InputLabel>Address</InputLabel>
//         <Input name="address" defaultValue={customer.customer.address} />
//       </FormControl>
//       <FormControl>
//         <InputLabel>Proof_Id</InputLabel>
//         <Input name="idVerificationtype" defaultValue={customer.customer.idVerificationtype} />
//       </FormControl>
//       <FormControl>
//         <InputLabel>Gender</InputLabel>
//         <Input name="gender" defaultValue={customer.customer.gender} />
//       </FormControl>
//       <FormControl>
//         <InputLabel>Age</InputLabel>
//         <Input name="age" defaultValue={customer.customer.age} />
//       </FormControl>

//       <Button  href="PassengerForm">Add Passenger</Button>
//       <PassengerForm  updatePass={getUpdatedPass} />
//       <FormControl>
//         <Button variant="contained" onClick={onPost}>Done</Button>
//       </FormControl>
//       <br />
//       <br />
//       <table
//         class="container-xxl col-md-6 mb-2 bordered-table "
//         id="results-table"
//       ></table>
//     </Container>
//   );
// }
export default function BookingPage(){
    const customer = JSON.parse(sessionStorage.getItem('customer'));
    const itineraries = JSON.parse(sessionStorage.getItem('itineraries'));
    //console.log(itineraries[0].departureId)
   // console.log(customer);
    const[arrayOfPass,setArrayOfPass] = useState([]);
    const getUpdatedPass=(arr)=>
    {
        setArrayOfPass(prevArray=>[...prevArray,arr]);
    }
    console.log("array of pass",arrayOfPass);
    function getCurrentDate()
    {
        const currentDate = new Date();
        const year = currentDate.getFullYear();
        const month = String(currentDate.getMonth() + 1).padStart(2, '0');
        const day = String(currentDate.getDate()).padStart(2, '0');
        return `${year}-${month}-${day}`;
    }
    const onPost=()=>{

        const bookiee ={
            bookingId:0,
            bookingDate :getCurrentDate(),
            noOfPassenger:arrayOfPass.length,
            tourAmount:10,
            taxes:0,
            totalAmount:0,
            masterId:itineraries[0].itinerary.masterId,
            customerId:customer.customer.customerId,
            departureId:itineraries[0].departureId,
            
        }
        const BookingData={
            booking:bookiee,
            passenger:arrayOfPass
        }
        console.log("BookingData",BookingData);
        fetch("https://localhost:7200/api/Book", {
            method: "POST",
            headers: { "Content-type": "application/json" },
            body: JSON.stringify(BookingData),
          })
            .then((res) => res.json()).
            then((res)=> console.log(res)).then((res)=> sessionStorage.setItem("ReturnData", JSON.stringify(res)))
            .then(console.log("DOne na bosssssssss"));
            //navigate('/BillingPage');

    }
    return(

        <Container>
            <Typography>Book Tour</Typography>
            <FormControl>
            <InputLabel>Name</InputLabel>
            <Input name="customerName" defaultValue={customer.customer.customerName}/>
            </FormControl>
            <FormControl>
            <InputLabel>Mail</InputLabel>
            <Input name="email" defaultValue={customer.customer.email}/>
            </FormControl>
            <FormControl>
            <InputLabel>Country Code</InputLabel>
            <Input name="countryCode" defaultValue={customer.customer.countryCode}/>
            </FormControl>
            <FormControl>
            <InputLabel>Phone Number</InputLabel>
            <Input name="phoneNumber"defaultValue={customer.customer.phoneNumber}/>
            </FormControl>
            <FormControl>
            <InputLabel>Address</InputLabel>
            <Input name="address" defaultValue={customer.customer.address}/>
            </FormControl>
            <FormControl>
            <InputLabel>Verification Type</InputLabel>
            <Input name="idVerificationType" defaultValue={customer.customer.idVerificationType}/>
            </FormControl>
            <FormControl>
            <InputLabel>Gender</InputLabel>
            <Input name="gender" defaultValue={customer.customer.gender}/>
            </FormControl>
            <FormControl>
            <InputLabel>Age</InputLabel>
            <Input name="age" defaultValue={customer.customer.age}/>
            </FormControl>
            <Button href="PassengerForm">Add Passenger</Button>
            <PassengerForm updatePass={getUpdatedPass}/>
            <FormControl>
                <Button variant="contained" onClick={onPost}>Done</Button>
            </FormControl>
            <br />
            <br />
      {/* <table
        class="container-xxl col-md-6 mb-2 bordered-table "
        id="results-table"
      ></table> */}
        </Container>









    )
}
