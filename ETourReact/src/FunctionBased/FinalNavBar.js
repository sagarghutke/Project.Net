// import { useEffect, useState } from "react";
// import { Button, Card, Table } from "react-bootstrap";
//import { useParams } from "react-router-dom";
//import Navbar from 'react-bootstrap/Navbar';
//import Container from 'react-bootstrap/Container';
//import Nav from 'react-bootstrap/Nav';


import { Button, Form } from 'react-bootstrap';
import Modal from "react-bootstrap/Modal";
import { useState } from 'react';
import * as Yup from 'yup';
import { useFormik } from 'formik';


export function LoginForm({ handleClose, handleShow, responseMessage, setResponseMessage, show , formik }) {
  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>Modal heading</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Form onSubmit={formik.handleSubmit}>
          <Form.Group controlId="Phone_Number">
            <Form.Label>Phone Number</Form.Label>
            <Form.Control
              type="tel"
              name="phoneNumber"
              value={formik.values.phoneNumber}
              onChange={formik.handleChange}
              onBlur={formik.handleBlur}
              isInvalid={formik.touched.phoneNumber && !!formik.errors.phoneNumber}
              placeholder="Enter phone number"
            />
            <Form.Control.Feedback type="invalid">
              {formik.errors.phoneNumber}
            </Form.Control.Feedback>
          </Form.Group>

          <Form.Group controlId="Password">
            <Form.Label>Password</Form.Label>
            <Form.Control
              type="password"
              name="password"
              value={formik.values.password}
              onChange={formik.handleChange}
              onBlur={formik.handleBlur}
              isInvalid={formik.touched.password && !!formik.errors.password}
              placeholder="Enter password"
            />
            <Form.Control.Feedback type="invalid">
              {formik.errors.password}
            </Form.Control.Feedback>
          </Form.Group>

          <Button variant="primary" onClick={formik.handleSubmit}>
            SignIN
          </Button>
          <Button variant="primary" href='/RegistrationForm'>
            SignUp
          </Button>

        </Form>
        {responseMessage}
      </Modal.Body>
    </Modal>
  );
}

 const Navigation=()=> {

    const validationSchema = Yup.object().shape({
              phoneNumber: Yup.number()
                .typeError('Phone number must be a number')
                .required('Phone number is required'),
              password: Yup.string()
                .required('Password is required')
                                        // .matches(
                                        //   /^(?=.\d)(?=.[a-z])(?=.[A-Z])(?=.[a-zA-Z]).{8,}$/,
                                        //   'Password must contain at least 8 characters, one uppercase letter, one lowercase letter, and one number or special character'
                                        // ),
            });
          
            const [show, setShow] = useState(false);
            const [responseMessage, setResponseMessage] = useState('');
             const [SignedIn, setSignedIn] = useState(false);
          
            const handleClose = () => setShow(false);
            const handleShow = () => setShow(true);
          
            const formik = useFormik({
              initialValues: {
                phoneNumber: '',
                password: ''
              },
              validationSchema: validationSchema,
              onSubmit: (values, { resetForm }) => {
                fetch("https://localhost:7200/api/Logins", {
                  method: 'POST',
                  headers: {
                    'Content-Type': 'application/json'
                  },
                  body: JSON.stringify(values)
                  
                })
                  .then(response => response.json())
                  .then(data => {
                    // console.log(data);
            
                    if (data) {
                                                        // setResponseMessage('Login done.');
                      alert('Login done.')
                      console.log(data);  
                      sessionStorage.setItem('customer',JSON.stringify(data));
                      sessionStorage.setItem('isLoggedIn', true);
                                                  // console.log(sessionStorage.getItem('isLoggedIn'))
                      setTimeout(handleClose, 1000); // Close modal after 1 seconds
                     setTimeout(resetForm, 1000); // for content reset if page refresh

                      setSignedIn(!SignedIn);
                    }
                     else {
                      sessionStorage.setItem('isLoggedIn', false);
                                                  // setResponseMessage('Login credentials are incorrect.');
                      setTimeout(resetForm, 500); // resetForm();

                       setSignedIn(SignedIn);
                      alert('Login credentials are incorrect.')
                    }
                    handleShow();
                  })
                  .catch(error => console.error(error));
              },
            });

            const handlehide =()=>  {
              sessionStorage.setItem('isLoggedIn', false); 
              setSignedIn(!SignedIn);
          }
          
  return (
    <div>
         <header>
        <nav class="navbar navbar-expand-lg bg-light">
            <div class="container-fluid">
                <a class="navbar-brand" href="/HomePage">TourIndia</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse"
                    data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent"
                    aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <a class="nav-link active" aria-current="page" href="/CategaryMasters">AllCategary</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="/FormPage">Form</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="/RegistrationForm">Registration</a>
                        </li>
                        {/* <li class="nav-item">
                            <a class="nav-link disabled">Disabled</a> 
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="">Contact us</a>
                        </li> */}
                        <li class="nav-item" >
                           {SignedIn ? <Button variant="primary" onClick={handlehide}>Sign Out</Button>: <Button variant="primary" onClick={handleShow}>Sign In</Button>}
                        </li>
                        <li class="nav-item" style={{marginLeft:"10px"}}>
                            <a type="button" class="btn btn-primary" href="/ContentSearch" style={{marginleft: "10px"}}>
                              Search
                            </a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    </header>
    <LoginForm
          show={show}
          handleClose={handleClose}
          handleShow={handleShow}
          responseMessage={responseMessage}
          setResponseMessage={setResponseMessage}
          formik={formik}
        />
    </div>
  );
}

export default Navigation


{/* {sessionStorage.getItem('isLoggedIn') ? <Button variant="primary" onClick={handlehide}>Sign Out</Button>: <Button variant="primary" onClick={handleShow}>Sign In</Button>} */}
{/* <Button variant="primary" onClick={handleShow}>{SignedIn ? "Sign Out" : "Sign In"} </Button> */}