import React from 'react'
import PropTypes from 'prop-types'
import { uuidv4 } from '../../../helper/utils'

type PolicyCardProps = {
    icon: any,
    name: string,
    description: string
}

const PolicyCard = (props: PolicyCardProps) => {
    return (
        <div id={uuidv4()} className="policy-card">
            <div className="policy-card__icon">
                <i className={props.icon}></i>
            </div>
            <div className="policy-card__info">
                <div className="policy-card__info__name">
                    {props.name}
                </div>
                <div className="policy-card__info__description">
                    {props.description}
                </div>
            </div>
        </div>
    )
}

export default PolicyCard
