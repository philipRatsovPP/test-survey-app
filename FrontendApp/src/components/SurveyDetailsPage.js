import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';

export function SurveyDetailsPage() {

    const params = useParams();
    const [survey, setSurvey] = useState(null);

    useEffect(() => {
        async function fetchData() {
            const response = await fetch(`survey/surveys/12`);
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