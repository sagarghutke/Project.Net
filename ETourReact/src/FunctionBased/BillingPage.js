import React from 'react';
import { Formik, Field, FieldArray } from 'formik';
import { TextField, DatePicker, CheckboxWithLabel } from 'formik-material-ui';
import { Button } from '@material-ui/core';

const initialValues = {
  name: '',
  bookingDate: null,
  passengerCount: 1,
  totalAmount: 0,
  tourAmount: 0,
  tax: 0,
  departureDate: null,
  passengers: [{ name: '', age: '' }]
};

const TourBookingForm = () => {
  const handleSubmit = (values) => {
    fetch('https://example.com/api/tour-bookings', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(values)
    })
      .then(response => {
        if (!response.ok) {
          throw new Error('Failed to submit form data');
        }
      })
      .catch(error => {
        console.error(error);
      });
  };

  return (
    <Formik
      initialValues={initialValues}
      onSubmit={handleSubmit}
    >
      {({ values }) => (
        <form onSubmit={handleSubmit}>
          <Field
            name="name"
            label="Name"
            component={TextField}
            fullWidth
          />
          <Field
            name="bookingDate"
            label="Booking Date"
            component={DatePicker}
            fullWidth
          />
          <Field
            name="passengerCount"
            label="Number of Passengers"
            component={TextField}
            fullWidth
          />
          <Field
            name="totalAmount"
            label="Total Amount"
            component={TextField}
            fullWidth
          />
          <Field
            name="tourAmount"
            label="Tour Amount"
            component={TextField}
            fullWidth
          />
          <Field
            name="tax"
            label="Tax"
            component={TextField}
            fullWidth
          />
          <Field
            name="departureDate"
            label="Departure Date"
            component={DatePicker}
            fullWidth
          />
          <FieldArray name="passengers">
            {({ push, remove }) => (
              <>
                {values.passengers.map((passenger, index) => (
                  <div key={index}>
                    <Field
                      name={`passengers.${index}.name`}
                      label="Passenger Name"
                      component={TextField}
                      fullWidth
                    />
                    <Field
                      name={`passengers.${index}.age`}
                      label="Passenger Age"
                      component={TextField}
                      fullWidth
                    />
                    <CheckboxWithLabel
                      name={`passengers.${index}.isAdult`}
                      Label={{ label: 'Adult' }}
                      control={<CheckboxWithLabel />}
                    />
                    <Button
                      type="button"
                      onClick={() => remove(index)}
                    >
                      Remove Passenger
                    </Button>
                  </div>
                ))}
                <Button
                  type="button"
                  onClick={() => push({ name: '', age: '', isAdult: false })}
                >
                  Add Passenger
                </Button>
              </>
            )}
          </FieldArray>
          <Button
            type="submit"
            color="primary"
            variant="contained"
          >
            Submit
          </Button>
        </form>
      )}
    </Formik>
  );
};

export default TourBookingForm;
