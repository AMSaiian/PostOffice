import React, { useState } from "react";

export const ParcelItem = () => {
    const [item, setItem] = useState({
        decription: "",
        itemCategory: ""
    })

    const [characteristics, setCharacteristics] = useState({
        width: 0,
        height: 0,
        depth: 0,
        weight: 0
    })

    return (
        <form className="parcel-item-form">
            <div className="width-wrapper">
                <label htmlFor="width">Width</label>
                <input type="number" className="parcel-item-form-control" id="width" value={characteristics.width} onChange={} placeholder="mm" />
            </div>
            <div className="height-wrapper">
                <label htmlFor="height">Height</label>
                <input type="number" className="parcel-item-form-control" id="height" value={characteristics.height} onChange={} placeholder="mm" />
            </div>
            <div className="depth-wrapper">
                <label htmlFor="depth">Depth</label>
                <input type="number" className="parcel-item-form-control" id="depth" value={characteristics.depth} onChange={} placeholder="mm" />
            </div>
            <div className="weight-wrapper">
                <label htmlFor="weight">Weight</label>
                <input type="number" className="parcel-item-form-control" id="depth" value={characteristics.depth} onChange={ } placeholder="mm" />
            </div>
        </form>
    )
}