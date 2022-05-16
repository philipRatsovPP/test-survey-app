import React from 'react';
import { useParams } from 'react-router-dom';
import { useEffect, useState } from 'react/cjs/react.production.min';

export function SurveyDetailsPage() {

    const params = useParams();
    const { survey, setSurvey } = useState();

    useEffect(() => {
        async function fetchData() {
            const id = params.id;
            const response = await fetch(`survey/surveys/${id}`);
            const data = await response.json();
            setSurvey(data.survey);
        }
        fetchData()
    }, [])

    console.log(params);
    console.log(survey);

    return (
        <div>
            A
        </div>
    )
}