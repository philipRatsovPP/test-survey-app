import React, { useState, useEffect } from 'react';
import { Form, FormGroup, Label, Input, Button } from 'reactstrap'
import { useParams, useHistory } from 'react-router-dom';

export function SurveyDetailsPage() {

    const history = useHistory();

    const params = useParams();
    const id = params.id;
    const [survey, setSurvey] = useState(null);

    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [email, setEmail] = useState('');
    const [age, setAge] = useState(null);

    useEffect(() => {
        async function fetchData() {
            const response = await fetch(`survey/surveys/${id}`);
            const data = await response.json();
            setSurvey(data.survey);
        }
        fetchData()
    }, [])

    const handleSubmit = async (event) => {
        const form = event.currentTarget;
        event.preventDefault();
        event.stopPropagation();
        
        if (form.checkValidity() === false) {
            return;
        }

        await fetch(`survey/response/${id}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                firstName,
                lastName,
                email,
                age,
            })
        });

        history.push('/');
    };

    if (!survey) { return null; }

    const firstNameFormProperty = survey.properties.firstName;
    const lastNameFormProperty = survey.properties.lastName;
    const emailFormProperty = survey.properties.email;
    const ageFormProperty = survey.properties.age;

    return (
        <div>
            <Form>
                <FormGroup style={{ marginBottom: '16px' }}>
                    <Label for="firstName">
                        {firstNameFormProperty.label}
                    </Label>
                    <Input
                        id="firstName"
                        name="firstName"
                        placeholder={firstNameFormProperty.label}
                        type="text"
                        required={firstNameFormProperty.required}
                        invalid={firstName === ''}
                        onChange={(e) => { setFirstName(e.target.value) }}
                    />
                </FormGroup>
                <FormGroup style={{ marginBottom: '16px' }}>
                    <Label for="lastName">
                        {lastNameFormProperty.label}
                    </Label>
                    <Input
                        id="lastName"
                        name="lastName"
                        placeholder={lastNameFormProperty.label}
                        type="text"
                        invalid={lastName === ''}
                        required={lastNameFormProperty.required}
                        onChange={(e) => { setLastName(e.target.value) }}
                    />
                </FormGroup>
                <FormGroup style={{ marginBottom: '16px' }}>
                    <Label for="email">
                        {emailFormProperty.label}
                    </Label>
                    <Input
                        id="email"
                        name="email"
                        placeholder={emailFormProperty.label}
                        type="text"
                        invalid={email === ''}
                        required={emailFormProperty.required}
                        onChange={(e) => { setEmail(e.target.value) }}
                    />
                </FormGroup>
                <FormGroup style={{ marginBottom: '16px' }}>
                    <Label for="age">
                        {ageFormProperty.label}
                    </Label>
                    <Input
                        id="age"
                        name="age"
                        placeholder={ageFormProperty.label}
                        type={ageFormProperty.type}
                        required={ageFormProperty.required}
                        onChange={(e) => { setAge(e.target.value) }}
                    />
                </FormGroup>
                <Button onClick={handleSubmit} type="submit">Submit survey</Button>
            </Form>
        </div>
    )
}