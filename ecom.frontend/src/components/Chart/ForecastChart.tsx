import React, { useState, useEffect } from 'react';
import ReactDOM from 'react-dom';
import { Line } from '@ant-design/plots';
import { Card, Divider } from 'antd';
import Forecast from '../../interface/Forecast';

const ForecastChart = ({ data }: { data: Forecast }) => {
  const [chartData, setChartData] = useState([]);

  useEffect(() => {
    setChartData(data.details.map(detail => ({ day: new Date(detail.date).getDate(), sold: detail.totalSold })));
  }, [])

  const config = {
    data: chartData,
    xField: 'day',
    yField: 'sold',

    label: {},
    point: {
      size: 5,
      shape: 'diamond',
      style: {
        fill: 'white',
        stroke: '#5B8FF9',
        lineWidth: 2,
      },
    },
    tooltip: {
      showMarkers: false,
    },
    state: {
      active: {
        style: {
          shadowBlur: 4,
          stroke: '#000',
          fill: 'red',
        },
      },
    },
    interactions: [
      {
        type: 'marker-active',
      },
    ],
  };
  return <>
    <div style={{ width: "25%" }}>
      <Card title="Cập nhật vào ngày">
        {data.lastUpdated.toString()}
      </Card>
    </div>
    <Divider />
    <Line {...config} />
  </>;
};

export default ForecastChart;
