// import React from 'react';
// import NavigationBar from './FunctionBased/Navbar';

// import {Outlet} from 'react-router-dom';



// function App() {
//   return (
//     <div>

//     <NavigationBar/>
//     { Categary.map(cat => ( 
//             <Card style={{ width: '18rem', margin:"25px" }}>
//             <Card.Img variant="top" src="/Images/tajmahal.jpg" />
//             <Card.Body>
//               <Card.Title>{cat.cat_Name}</Card.Title>
//               <Card.Text>
//               {cat.cat_Id}
//               {cat.flag}
//               </Card.Text>

//               {(cat.flag == true) ? (<Button variant="primary" href={"/Itineraries/"}>Itit</Button>) : (<Button variant="primary" href={"/Search/"+cat.catMaster_Id}>Display</Button>) }
//             </Card.Body>
//           </Card>
//         ))
//         }
//     <Outlet/>
//     </div>
//   )
// }
// export default App;
